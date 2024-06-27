using System;

class Program
{
    static int[,] matris;

    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Lineer Cebir Hesaplamalar // Hesaplamalar tamamen kare matrise göre yapılmalıdır !");
        Console.WriteLine("\n");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("| [1] Matrisin Determinantını Hesapla |");
        Console.WriteLine("| [2] Ek Matrisi Hesapla               |");
        Console.WriteLine("| [3] Matrisin Tersini Hesapla         |");
        Console.WriteLine("| [4] Matrisin Transpozunu Hesapla     |");
        Console.WriteLine("| [5] Matrisin Kofaktörünü Hesapla     |");
        Console.WriteLine("| [0] Ana Menüye Dön                   |");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("Lütfen yapacağınız işlemi seçiniz: ");
        int mod = Convert.ToInt32(Console.ReadLine());

        switch (mod)
        {
            case 1:
                Console.Clear();
                matrisOlustur();
                Console.WriteLine("Girdiğiniz Matrisin Determinantı: {0}", determinant(matris, matris.GetLength(1), matris.GetLength(0)));
                break;
            case 2:
                Console.Clear();
                matrisOlustur();
                ekMatris(matris, matris.GetLength(1), matris.GetLength(0));
                break;
            case 3:
                Console.Clear();
                matrisOlustur();
                tersMatris(matris, matris.GetLength(1), matris.GetLength(0));
                break;
            case 4:
                Console.Clear();
                matrisOlustur();
                transpozMatris(matris, matris.GetLength(1), matris.GetLength(0));
                break;
            case 5:
                Console.Clear();
                matrisOlustur();
                kofaktorMatris(matris, matris.GetLength(1), matris.GetLength(0));
                break;
            case 0:
                Console.Clear();
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Geçersiz işlem seçimi !");
                break;
        }

        Console.ReadLine();
    }

    static void matrisOlustur()
    {
        Console.WriteLine("Matrisinizin boyutunu giriniz (örn. 3x3 için 3 giriniz): ");
        int boyut = Convert.ToInt32(Console.ReadLine());
        matris = new int[boyut, boyut];

        for (int i = 0; i < boyut; i++)
        {
            for (int j = 0; j < boyut; j++)
            {
                Console.WriteLine("Lütfen matrisinizin {0}. satırın {1}. sütunundaki sayıyı giriniz: ", i + 1, j + 1);
                matris[i, j] = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
        }
    }

    static int determinant(int[,] matris, int sutun, int satir)
    {
        int detA;
        if (satir == 1 && sutun == 1)
        {
            detA = matris[0, 0];
        }
        else if (satir == 2 && sutun == 2)
        {
            detA = matris[0, 0] * matris[1, 1] - matris[0, 1] * matris[1, 0];
        }
        else if (satir == 3 && sutun == 3)
        {
            detA = matris[0, 0] * matris[1, 1] * matris[2, 2] + matris[1, 0] * matris[2, 1] * matris[0, 2]
                 + matris[2, 0] * matris[0, 1] * matris[1, 2] - matris[2, 0] * matris[1, 1] * matris[0, 2]
                 - matris[0, 0] * matris[2, 1] * matris[1, 2] - matris[1, 0] * matris[0, 1] * matris[2, 2];
        }
        else
        {
            Console.WriteLine("Girdiğiniz matrisin determinantı alınamıyor !");
            return 0;
        }

        return detA;
    }

    static void ekMatris(int[,] matris, int sutun, int satir)
    {
        int det = determinant(matris, sutun, satir);
        if (det == 0)
        {
            Console.WriteLine("Matrisin determinantı 0 olduğu için ek matrisi hesaplanamaz.");
            return;
        }

        int[,] kofaktor = new int[satir, sutun];
        for (int i = 0; i < satir; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                kofaktor[i, j] = Cofactor(matris, i, j) / det;
            }
        }

        Console.WriteLine("Girdiğiniz Matrisin Ek Matrisi:");
        Console.WriteLine("--------------------------------");
        for (int i = 0; i < satir; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                Console.Write(kofaktor[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Ana sayfaya dönmek için bir tuşa basın lütfen !");
        Console.ReadLine();
        Main();
    }

    static void tersMatris(int[,] matris, int sutun, int satir)
    {
        int det = determinant(matris, sutun, satir);
        if (det == 0)
        {
            Console.WriteLine("Matrisin determinantı 0 olduğu için ters matrisi hesaplanamaz.");
            return;
        }

        int[,] kofaktor = new int[satir, sutun];
        for (int i = 0; i < satir; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                kofaktor[i, j] = Cofactor(matris, i, j) / det;
            }
        }

        Console.WriteLine("Girdiğiniz Matrisin Tersi:");
        Console.WriteLine("--------------------------------");
        for (int i = 0; i < satir; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                Console.Write(kofaktor[j, i] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Ana sayfaya dönmek için bir tuşa basın lütfen !");
        Console.ReadLine();
        Main();
    }

    static int Cofactor(int[,] matris, int row, int col)
    {
        return (int)Math.Pow(-1, row + col) * determinant(SubMatrix(matris, row, col),
            matris.GetLength(1) - 1, matris.GetLength(0) - 1);
    }

    static int[,] SubMatrix(int[,] matris, int row, int col)
    {
        int[,] subMatrix = new int[matris.GetLength(0) - 1, matris.GetLength(1) - 1];
        int ri = 0, ci = 0;
        for (int i = 0; i < matris.GetLength(0); i++)
        {
            if (i == row)
                continue;

            ci = 0;
            for (int j = 0; j < matris.GetLength(1); j++)
            {
                if (j == col)
                    continue;

                subMatrix[ri, ci] = matris[i, j];
                ci++;
            }
            ri++;
        }
        return subMatrix;
    }

    static void kofaktorMatris(int[,] matris, int sutun, int satir)
    {
        int det = determinant(matris, sutun, satir);
        if (det == 0)
        {
            Console.WriteLine("Matrisin determinantı 0 olduğu için kofaktör matrisi hesaplanamaz.");
            return;
        }

        int[,] kofaktor = new int[satir, sutun];
        for (int i = 0; i < satir; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                kofaktor[i, j] = Cofactor(matris, i, j);
            }
        }

        Console.WriteLine("Girdiğiniz Matrisin Kofaktör Matrisi:");
        Console.WriteLine("--------------------------------");
        for (int i = 0; i < satir; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                Console.Write(kofaktor[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Ana sayfaya dönmek için bir tuşa basın lütfen !");
        Console.ReadLine();
        Main();
    }

    static void transpozMatris(int[,] matris, int sutun, int satir)
    {
        int[,] transpoz = new int[sutun, satir];
        for (int i = 0; i < satir; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                transpoz[i, j] = matris[j, i];
            }
        }

        Console.WriteLine("Girdiğiniz Matrisin Transpozu:");
        Console.WriteLine("--------------------------------");
        for (int i = 0; i < sutun; i++)
        {
            for (int j = 0; j < satir; j++)
            {
                Console.Write(transpoz[i, j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Ana sayfaya dönmek için bir tuşa basın lütfen !");
        Console.ReadLine();
        Main();
    }
}

