using System;

class Program
{
static int[,] matris;

static void Main()
{
Console.Clear();
Console.WriteLine(&quot;Lineer Cebir Hesaplamalar // Hesaplamalar tamamen kare matrise
göre yapılmalıdır !&quot;);
Console.WriteLine(&quot;\n&quot;);
Console.WriteLine(&quot;---------------------------------------&quot;);
Console.WriteLine(&quot;| [1] Matrisin Determinantını Hesapla |&quot;);
Console.WriteLine(&quot;| [2] Ek Matrisi Hesapla |&quot;);
Console.WriteLine(&quot;| [3] Matrisin Tersini Hesapla |&quot;);
Console.WriteLine(&quot;| [4] Matrisin Transpozunu Hesapla |&quot;);
Console.WriteLine(&quot;| [5] Matrisin Kofaktörünü Hesapla |&quot;);
Console.WriteLine(&quot;| [0] Ana Menüye Dön |&quot;);
Console.WriteLine(&quot;---------------------------------------&quot;);
Console.WriteLine(&quot;Lütfen yapacağınız işlemi seçiniz: &quot;);
int mod = Convert.ToInt32(Console.ReadLine());
switch (mod)
{
case 1:
Console.Clear();
matrisOlustur();

Console.WriteLine(&quot;Girdiğiniz Matrisin Determinantı: {0}&quot;, determinant(matris,
matris.GetLength(1), matris.GetLength(0)));
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
Main();
break;
default:
Console.WriteLine(&quot;Geçersiz işlem seçimi !&quot;);
break;

}
Console.ReadLine();
}

static void matrisOlustur()
{
Console.WriteLine(&quot;Matrisinizin satır sayısını giriniz: &quot;);
int satir = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(&quot;Matrisinizin sütun sayısını giriniz: &quot;);
int sutun = Convert.ToInt32(Console.ReadLine());
matris = new int[satir, sutun];

for (int i = 0; i &lt; satir; i++)
{
for (int j = 0; j &lt; sutun; j++)
{
Console.WriteLine(&quot;Lütfen matrisinizin {0}. satırın {1}. sütunundaki sayıyı giriniz:
&quot;, i + 1, j + 1);
matris[i, j] = Convert.ToInt32(Console.ReadLine());
Console.Clear();
}
}
}

static int determinant(int[,] matris, int sutun, int satir)
{
int detA;
if (satir == 1 &amp;&amp; sutun == 1)
{
detA = matris[0, 0];
}

else if (satir == 2 &amp;&amp; sutun == 2)
{
detA = matris[0, 0] * matris[1, 1] - matris[0, 1] * matris[1, 0];
}
else if (satir == 3 &amp;&amp; sutun == 3)
{
detA = matris[0, 0] * matris[1, 1] * matris[2, 2] + matris[1, 0] * matris[2, 1] *
matris[0, 2] + matris[2, 0] * matris[0, 1] * matris[1, 2] -
matris[2, 0] * matris[1, 1] * matris[0, 2] - matris[0, 0] * matris[2, 1] * matris[1, 2]
- matris[1, 0] * matris[0, 1] * matris[2, 2];
}
else
{
Console.WriteLine(&quot;Girdiğiniz matrisin determinantı alınamıyor !&quot;);
return 0;
}

return detA;
}

static void ekMatris(int[,] matris, int sutun, int satir)
{
int det = determinant(matris, sutun, satir);
if (det == 0)
{
Console.WriteLine(&quot;Matrisin determinantı 0 olduğu için ek matrisi hesaplanamaz.&quot;);
return;
}

int[,] kofaktor = new int[satir, sutun];
for (int i = 0; i &lt; satir; i++)

{
for (int j = 0; j &lt; sutun; j++)
{
kofaktor[i, j] = Cofactor(matris, i, j) / det;
}
}

Console.WriteLine(&quot;Girdiğiniz Matrisin Ek Matrisi:&quot;);
Console.WriteLine(&quot;--------------------------------&quot;);
for (int i = 0; i &lt; satir; i++)
{
for (int j = 0; j &lt; sutun; j++)
{
Console.Write(kofaktor[i, j] + &quot; &quot;);
}
Console.WriteLine();
}
Console.WriteLine(&quot;--------------------------------&quot;);
Console.WriteLine(&quot;Ana sayfaya dönmek için bir tuşa basın lütfen !&quot;);
Console.ReadLine();
Main();
}

static void tersMatris(int[,] matris, int sutun, int satir)
{
int det = determinant(matris, sutun, satir);
if (det == 0)
{
Console.WriteLine(&quot;Matrisin determinantı 0 olduğu için ters matrisi hesaplanamaz.&quot;);
return;

}

int[,] kofaktor = new int[satir, sutun];
for (int i = 0; i &lt; satir; i++)
{
for (int j = 0; j &lt; sutun; j++)
{
kofaktor[i, j] = Cofactor(matris, i, j) / det;
}
}

Console.WriteLine(&quot;Girdiğiniz Matrisin Tersi:&quot;);
Console.WriteLine(&quot;--------------------------------&quot;);
for (int i = 0; i &lt; satir; i++)
{
for (int j = 0; j &lt; sutun; j++)
{
Console.Write(kofaktor[j, i] + &quot; &quot;);
}
Console.WriteLine();
}
Console.WriteLine(&quot;--------------------------------&quot;);
Console.WriteLine(&quot;Ana sayfaya dönmek için bir tuşa basın lütfen !&quot;);
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
for (int i = 0; i &lt; matris.GetLength(0); i++)
{
if (i == row)
continue;

ci = 0;
for (int j = 0; j &lt; matris.GetLength(1); j++)
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

Console.WriteLine(&quot;Matrisin determinantı 0 olduğu için kofaktör matrisi
hesaplanamaz.&quot;);
return;
}

int[,] kofaktor = new int[satir, sutun];
for (int i = 0; i &lt; satir; i++)
{
for (int j = 0; j &lt; sutun; j++)
{
kofaktor[i, j] = Cofactor(matris, i, j);
}
}

Console.WriteLine(&quot;Girdiğiniz Matrisin Kofaktör Matrisi:&quot;);
Console.WriteLine(&quot;--------------------------------&quot;);
for (int i = 0; i &lt; satir; i++)
{
for (int j = 0; j &lt; sutun; j++)
{
Console.Write(kofaktor[i, j] + &quot; &quot;);
}
Console.WriteLine();
}
Console.WriteLine(&quot;--------------------------------&quot;);
Console.WriteLine(&quot;Ana sayfaya dönmek için bir tuşa basın lütfen !&quot;);
Console.ReadLine();
Main();
}

static void transpozMatris(int[,] matris, int sutun, int satir)

{
int[,] transpoz = new int[sutun, satir];
for (int i = 0; i &lt; satir; i++)
{
for (int j = 0; j &lt; sutun; j++)
{
transpoz[i, j] = matris[j, i];
}
}

Console.WriteLine(&quot;Girdiğiniz Matrisin Transpozu:&quot;);
Console.WriteLine(&quot;--------------------------------&quot;);
for (int i = 0; i &lt; sutun; i++)
{
for (int j = 0; j &lt; satir; j++)
{
Console.Write(transpoz[i, j] + &quot; &quot;);
}
Console.WriteLine();
}
Console.WriteLine(&quot;--------------------------------&quot;);
Console.WriteLine(&quot;Ana sayfaya dönmek için bir tuşa basın lütfen !&quot;);
Console.ReadLine();
Main();
}
}
