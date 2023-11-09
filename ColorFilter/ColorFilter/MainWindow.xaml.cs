using Microsoft.Win32;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ColorFilter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage bitmap;
        BitmapImage Original;
        double width;
        double height;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "C:\\Users\\kozen\\Downloads\\cat pics\\cat pics";
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg; *.jpeg; *.png";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(openFileDialog.FileName);
                bitmap.EndInit();
                Original = bitmap;
                myImage.Source = bitmap;
            }
        }
        public void Barvy(object sender, RoutedEventArgs e)
        {
            var param = (string)((Button)sender).Tag;
            var arr = BitmapImageToArray2D(bitmap);
            int pruhy_x = 0;
            int pocet = 80;
            /*for (int row = 0; row < arr.GetLength(0) - 1; row++)*/
            Parallel.For(0, arr.GetLength(0) - 1, row =>
            {
                int pruhy_y = 0;
                for (int col = 0; col < arr.GetLength(1) - 1; col++)
                {
                    int color = arr[row, col];
                    var a = (color >> 24) & 0xFF; //alpha
                    var r = (color >> 16) & 0xFF; //red
                    var g = (color >> 8) & 0xFF; //green
                    var b = (color >> 0) & 0xFF; //blue
                    int average = ((r + g + b) / 3);

                    var blue = (color & 0xFF);// Blue
                    var green = ((color & 0xFF00));// Green
                    var red = ((color & 0xFF0000));// Red



                    if (param == "red")
                        arr[row, col] = red;
                    else if (param == "green")
                        arr[row, col] = green;
                    else if (param == "blue")
                        arr[row, col] = blue;
                    else if (param == "gray")
                    {
                        if (average > 255)
                            average = 255;
                        arr[row, col] = (a << 24) + (average << 16) + (average << 8) + average;
                    }

                    else if (param == "negative")
                    {
                        arr[row, col] = ((255 - a) << 24) + ((255 - r) << 16) + ((255 - g) << 8) + 255 - b;

                    }
                    else if (param == "pruhy")
                    {
                        if (pruhy_x < pocet / 2 && pruhy_y < pocet / 2)
                            arr[row, col] = (a << 24) + (average << 16) + (average << 8) + average;
                        else
                            arr[row, col] = (a << 24) + (r << 16) + (g << 8) + b;
                    }
                    else if (param == "random")
                    {
                        Random random = new Random();
                        int rand = random.Next(3);
                        if (rand == 0) arr[row, col] = red;
                        else if (rand == 1) arr[row, col] = green;
                        else arr[row, col] = blue;
                    }
                    else if (param == "brown")
                    {
                        arr[row, col] = (a << 24) + ((int)(r * 0.75) << 16) + ((int)(g * 0.6) << 8) + (int)(b * 0.41);
                    }
                    else if (param == "sepie")
                    {
                        int newR = (int)(r * 0.393 + g * 0.769 + b * 0.189);
                        int newG = (int)(r * 0.349 + g * 0.686 + b * 0.168);
                        int newB = (int)(r * 0.272 + g * 0.534 + b * 0.131);
                        if (newR > 255) newR = 255;
                        if (newG > 255) newG = 255;
                        if (newB > 255) newB = 255;
                        arr[row, col] = (a << 24) + (newR << 16) + (newG << 8) + newB;
                    }
                    pruhy_y++;
                    if (pruhy_y == pocet)
                        pruhy_y = 0;
                }
                pruhy_x++;
                if (pruhy_x == pocet)
                    pruhy_x = 0;
            });
            var wb = Array2DToWriteableBitmap(arr, bitmap);
            bitmap = ConvertWriteableBitmapToBitmapImage(wb);
            myImage.Source = bitmap;
        }
        public void ROriginal(object sender, RoutedEventArgs e)
        {
            bitmap = Original;
            myImage.Source = Original;
        }
        public void Reduce(object sender, RoutedEventArgs e)
        {
            var arr = BitmapImageToArray2D(bitmap);
            /*for (int row = 0; row < arr.GetLength(0); row++)*/
            Parallel.For(0, arr.GetLength(0) - 1, row =>
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    int color = arr[row, col];
                    var a = (color >> 24) & 0xA0; //alpha
                    var r = (color >> 16) & 0xA0; //red
                    var g = (color >> 8) & 0xA0; //green
                    var b = (color >> 0) & 0xA0; //blue
                    arr[row, col] = (a << 24) + (r << 16) + (g << 8) + b;
                }
            });
            var wb = Array2DToWriteableBitmap(arr, bitmap);
            bitmap = ConvertWriteableBitmapToBitmapImage(wb);
            myImage.Source = bitmap;
        }
        public void Pixelate(object sender, RoutedEventArgs e)
        {
            var arr = BitmapImageToArray2D(bitmap); 
            arr = Pixelate(arr, 50);
            var wb = Array2DToWriteableBitmap(arr, bitmap);
            bitmap = ConvertWriteableBitmapToBitmapImage(wb);
            myImage.Source = bitmap;
        }
        public void PixelateParallel(object sender, RoutedEventArgs e)
        {
            var arr = BitmapImageToArray2D(bitmap);
            arr = PixelateParallel(arr, 50);
            var wb = Array2DToWriteableBitmap(arr, bitmap);
            bitmap = ConvertWriteableBitmapToBitmapImage(wb);
            myImage.Source = bitmap;
        }
        /*public void Koule(object sender, RoutedEventArgs e)
        {
            int[,] arr = BitmapImageToArray2D(bitmap);
            arr = Test2(arr, (int)MySlider.Value*100);
            var wb = Array2DToWriteableBitmap(arr, bitmap);
            bitmap = ConvertWriteableBitmapToBitmapImage(wb);
            myImage.Source = bitmap;
        }*/
        public void Zrcadlo(object sender, RoutedEventArgs e)
        {
            int[,] arr = BitmapImageToArray2D(bitmap);
            arr = ApplyMirrorFilter(arr);
            var wb = Array2DToWriteableBitmap(arr, bitmap);
            bitmap = ConvertWriteableBitmapToBitmapImage(wb);
            myImage.Source = bitmap;
        }
        public void ParallelZrcadlo(object sender, RoutedEventArgs e)
        {
            int[,] arr = BitmapImageToArray2D(bitmap);
            arr = ApplyMirrorFilterParallel(arr);
            var wb = Array2DToWriteableBitmap(arr, bitmap);
            bitmap = ConvertWriteableBitmapToBitmapImage(wb);
            myImage.Source = bitmap;
        }
        public void Bublina(object sender, RoutedEventArgs e)
        {
            int[,] arr = BitmapImageToArray2D(bitmap);
            arr = ApplyBulgeFilter(arr, (float)MySlider.Value);
            var wb = Array2DToWriteableBitmap(arr, bitmap);
            bitmap = ConvertWriteableBitmapToBitmapImage(wb);
            myImage.Source = bitmap;
        }
        public void ParallelBublina(object sender, RoutedEventArgs e)
        {
            int[,] arr = BitmapImageToArray2D(bitmap);
            arr = ApplyBulgeFilterParallel(arr, (float)MySlider.Value);
            var wb = Array2DToWriteableBitmap(arr, bitmap);
            bitmap = ConvertWriteableBitmapToBitmapImage(wb);
            myImage.Source = bitmap;
        }
        public void Spiral(object sender, RoutedEventArgs e)
        {
            int[,] arr = BitmapImageToArray2D(bitmap);
            arr = ApplySwirlFilter(arr, 0.0009f);
            var wb = Array2DToWriteableBitmap(arr, bitmap);
            bitmap = ConvertWriteableBitmapToBitmapImage(wb);
            myImage.Source = bitmap;
        }
        public void ParallelSpiral(object sender, RoutedEventArgs e)
        {
            int[,] arr = BitmapImageToArray2D(bitmap);
            arr = ApplySwirlFilterParallel(arr, 0.0009f);
            var wb = Array2DToWriteableBitmap(arr, bitmap);
            bitmap = ConvertWriteableBitmapToBitmapImage(wb);
            myImage.Source = bitmap;
        }
        public void EdgeDetect(object sender, RoutedEventArgs e)
        {
            int[,] arr = BitmapImageToArray2D(bitmap);
            arr = SobelFilter(arr);
            var wb = Array2DToWriteableBitmap(arr, bitmap);
            bitmap = ConvertWriteableBitmapToBitmapImage(wb);
            myImage.Source = bitmap;
        }
        public static int[,] Pixelate(int[,] pixels, int pixelSize)
        {
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);

            int[,] pixelatedPixels = new int[width, height];

            for (int y = 0; y < height; y += pixelSize)
            //Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x += pixelSize)
                {
                    int r = 0;
                    int g = 0;
                    int b = 0;

                    int count = 1;

                    for (int y2 = y; y2 < y + pixelSize && y2 < height; y2++)
                    {
                        for (int x2 = x; x2 < x + pixelSize && x2 < width; x2++)
                        {
                            int pixel = pixels[x2, y2];

                            r += (pixel >> 16) & 0xff;
                            g += (pixel >> 8) & 0xff;
                            b += pixel & 0xff;

                            count++;
                        }
                    }

                    r /= count;
                    g /= count;
                    b /= count;

                    int avgColor = (r << 16) | (g << 8) | b;

                    for (int y2 = y; y2 < y + pixelSize && y2 < height; y2++)
                    {
                        for (int x2 = x; x2 < x + pixelSize && x2 < width; x2++)
                        {
                            pixelatedPixels[x2, y2] = avgColor;
                        }
                    }
                }
            }

            return pixelatedPixels;
        }
        public static int[,] PixelateParallel(int[,] pixels, int pixelSize)
        {
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);
            int[,] pixelatedPixels = new int[width, height];

            Parallel.For(0, height / pixelSize, y =>
            {
                for (int x = 0; x < width; x += pixelSize)
                {
                    int r = 0;
                    int g = 0;
                    int b = 0;

                    int count = 1;

                    for (int y2 = y * pixelSize; y2 < (y + 1) * pixelSize && y2 < height; y2++)
                    {
                        for (int x2 = x; x2 < x + pixelSize && x2 < width; x2++)
                        {
                            int pixel = pixels[x2, y2];

                            r += (pixel >> 16) & 0xff;
                            g += (pixel >> 8) & 0xff;
                            b += pixel & 0xff;

                            count++;
                        }
                    }

                    r /= count;
                    g /= count;
                    b /= count;

                    int avgColor = (r << 16) | (g << 8) | b;

                    for (int y2 = y * pixelSize; y2 < (y + 1) * pixelSize && y2 < height; y2++)
                    {
                        for (int x2 = x; x2 < x + pixelSize && x2 < width; x2++)
                        {
                            lock (pixelatedPixels)
                            {
                                pixelatedPixels[x2, y2] = avgColor;
                            }
                        }
                    }
                }
            });

            return pixelatedPixels;
        }

            /*public static int[,] Test2(int[,] pixels, int pixelSize)
        {
            int width = pixels.GetLength(0);
            int height = pixels.GetLength(1);
            var random = new Random();

            int[,] pixelatedPixels = new int[width, height];

            for (int y = 0; y < height; y += pixelSize)
            /*Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x += pixelSize)
                {
                    int a = 0;
                    int r = 0;
                    int g = 0;
                    int b = 0;

                    int count = 0;

                    for (int y2 = y; y2 < y + pixelSize && y2 < height; y2++)
                    {
                        for (int x2 = x; x2 < x + pixelSize && x2 < width; x2++)
                        {
                            int pixel = pixels[x2, y2];
                            a += (pixel >> 24) & 0xff;
                            r += (pixel >> 16) & 0xff;
                            g += (pixel >> 8) & 0xff;
                            b += pixel & 0xff;
                            count++;
                        }
                    }
                    r /= count;
                    g /= count;
                    b /= count;

                    var m = random.Next(2);
                    for (int y2 = y; y2 < y + pixelSize && y2 < height; y2++)
                    {
                        for (int x2 = x; x2 < x + pixelSize && x2 < width; x2++)
                        {
                            if (m == 0)
                            {
                                pixelatedPixels[x2, y2] = (a << 24) + ((int)(r * 0.75) << 16) + ((int)(g * 0.6) << 8) + (int)(b * 0.41);
                            }
                            else if (m == 1)
                            {
                                int average = ((r + g + b) / 3);
                                if (average > 255)
                                    average = 255;
                                pixelatedPixels[x2, y2] = (a << 24) + (average << 16) + (average << 8) + average;
                            }

                        }
                    }
                }
            }

            return pixelatedPixels;
        }*/
        public static int[,] ApplyMirrorFilter(int[,] input)
        {
            // Vstupní pole.
            int width = input.GetLength(0);
            int height = input.GetLength(1);

            // Výstupní pole.
            int[,] output = new int[width, height];

            // Pro každý řádek vstupního pole aplikujeme filtr zrcadlení pouze na druhou polovinu.
            for (int y = 0; y < height / 2; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int index = height - y - 1;
                    output[x, index] = input[x, y];
                    output[x, y] = input[x, y];
                }
            }

            // Vrátíme výstupní pole.
            return output;
        }
        public static int[,] ApplyMirrorFilterParallel(int[,] input)
        {
            // Vstupní pole.
            int width = input.GetLength(0);
            int height = input.GetLength(1);
            // Výstupní pole.
            int[,] output = new int[width, height];

            // Pro každý řádek vstupního pole aplikujeme filtr zrcadlení pouze na druhou polovinu.
            Parallel.For(0, height / 2, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    int index = height - y - 1;
                    output[x, index] = input[x, y];
                    output[x, y] = input[x, y];
                }
            });

            // Vrátíme výstupní pole.
            return output;
        }

        public static int[,] ApplyBulgeFilter(int[,] input, float strength)
        {
            // Vstupní pole.
            int width = input.GetLength(0);
            int height = input.GetLength(1);

            // Střed obrázku.
            int centerX = width / 2;
            int centerY = height / 2;

            // Výstupní pole.
            int[,] output = new int[width, height];

            // Projdeme každý pixel vstupního pole a aplikujeme na něj vypouklý efekt.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Vzdálenost mezi aktuálním pixelem a středem obrázku.
                    double distance = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));

                    // Výpočet vzdálenosti pixelu od středu v poměru k poloměru obrázku.
                    double radiusRatio = distance / centerX;

                    // Pokud je pixel blíže středu než poloměr obrázku, aplikujeme na něj efekt.
                    if (radiusRatio < 1)
                    {
                        // Vypočteme vzdálenost od středu podle strength.
                        double bulgeAmount = strength * Math.Sqrt(1 - Math.Pow(radiusRatio, 2));

                        // Vypočteme nové souřadnice pixelu s efektem vypouklého tvaru.
                        int bulgeX = (int)(x + bulgeAmount * (x - centerX));
                        int bulgeY = (int)(y + bulgeAmount * (y - centerY));

                        // Zkontrolujeme, zda nové souřadnice pixelu nejsou mimo rozsah obrázku.
                        if (bulgeX >= 0 && bulgeX < width && bulgeY >= 0 && bulgeY < height)
                        {
                            // Nakopírujeme barvu z nových souřadnic pixelu na výstupní pole.
                            output[x, y] = input[bulgeX, bulgeY];
                        }
                    }
                    else
                    {
                        // Pokud je pixel dále od středu než poloměr obrázku, překopírujeme ho na výstupní pole.
                        output[x, y] = input[x, y];
                    }
                }
            }

            // Vrátíme výstupní pole.
            return output;
        }
        public static int[,] ApplyBulgeFilterParallel(int[,] input, float strength)
        {
            // Vstupní pole.
            int width = input.GetLength(0);
            int height = input.GetLength(1);

            // Střed obrázku.
            int centerX = width / 2;
            int centerY = height / 2;

            // Výstupní pole.
            int[,] output = new int[width, height];

            // Projdeme každý pixel vstupního pole a aplikujeme na něj vypouklý efekt.
            Parallel.For(0, height, y =>
            {
                for (int x = 0; x < width; x++)
                {
                    // Vzdálenost mezi aktuálním pixelem a středem obrázku.
                    double distance = Math.Sqrt(Math.Pow(x - centerX, 2) + Math.Pow(y - centerY, 2));

                    // Výpočet vzdálenosti pixelu od středu v poměru k poloměru obrázku.
                    double radiusRatio = distance / centerX;

                    // Pokud je pixel blíže středu než poloměr obrázku, aplikujeme na něj efekt.
                    if (radiusRatio < 1)
                    {
                        // Vypočteme vzdálenost od středu podle strength.
                        double bulgeAmount = strength * Math.Sqrt(1 - Math.Pow(radiusRatio, 2));

                        // Vypočteme nové souřadnice pixelu s efektem vypouklého tvaru.
                        int bulgeX = (int)(x + bulgeAmount * (x - centerX));
                        int bulgeY = (int)(y + bulgeAmount * (y - centerY));

                        // Zkontrolujeme, zda nové souřadnice pixelu nejsou mimo rozsah obrázku.
                        if (bulgeX >= 0 && bulgeX < width && bulgeY >= 0 && bulgeY < height)
                        {
                            // Nakopírujeme barvu z nových souřadnic pixelu na výstupní pole.
                            output[x, y] = input[bulgeX, bulgeY];
                        }
                    }
                    else
                    {
                        // Pokud je pixel dále od středu než poloměr obrázku, překopírujeme ho na výstupní pole.
                        output[x, y] = input[x, y];
                    }
                }
            });

            // Vrátíme výstupní pole.
            return output;
        }

        public static int[,] ApplySwirlFilter(int[,] image, float swirlStrength)
        {
            int width = image.GetLength(0);
            int height = image.GetLength(1);
            int[,] result = new int[width, height];

            float centerX = width / 2f;
            float centerY = height / 2f;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    float dx = x - centerX;
                    float dy = y - centerY;
                    float distance = MathF.Sqrt(dx * dx + dy * dy);
                    float angle = MathF.Atan2(dy, dx);

                    float swirlAmount = swirlStrength * distance;
                    float swirlX = centerX + MathF.Cos(angle + swirlAmount) * distance;
                    float swirlY = centerY + MathF.Sin(angle + swirlAmount) * distance;

                    if (swirlX >= 0 && swirlX < width && swirlY >= 0 && swirlY < height)
                    {
                        result[(int)swirlX, (int)swirlY] = image[x, y];
                    }
                }
            }

            return result;
        }
        public static int[,] ApplySwirlFilterParallel(int[,] image, float swirlStrength)
        {
            int width = image.GetLength(0);
            int height = image.GetLength(1);
            int[,] result = new int[width, height];

            float centerX = width / 2f;
            float centerY = height / 2f;

            Parallel.For(0, width, x =>
            {
                for (int y = 0; y < height; y++)
                {
                    float dx = x - centerX;
                    float dy = y - centerY;
                    float distance = MathF.Sqrt(dx * dx + dy * dy);
                    float angle = MathF.Atan2(dy, dx);

                    float swirlAmount = swirlStrength * distance;
                    float swirlX = centerX + MathF.Cos(angle + swirlAmount) * distance;
                    float swirlY = centerY + MathF.Sin(angle + swirlAmount) * distance;

                    if (swirlX >= 0 && swirlX < width && swirlY >= 0 && swirlY < height)
                    {
                        result[(int)swirlX, (int)swirlY] = image[x, y];
                    }
                }
            });

            return result;
        }
        public static int[,] SobelFilter(int[,] inputImage)
        {
            int width = inputImage.GetLength(0);
            int height = inputImage.GetLength(1);
            int[,] outputImage = new int[width, height];

            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            for (int x = 1; x < width - 1; x++)
            {
                for (int y = 1; y < height - 1; y++)
                {
                    int pixelX = (gx[0, 0] * inputImage[x - 1, y - 1]) + (gx[0, 1] * inputImage[x, y - 1]) + (gx[0, 2] * inputImage[x + 1, y - 1]) +
                                 (gx[1, 0] * inputImage[x - 1, y]) + (gx[1, 1] * inputImage[x, y]) + (gx[1, 2] * inputImage[x + 1, y]) +
                                 (gx[2, 0] * inputImage[x - 1, y + 1]) + (gx[2, 1] * inputImage[x, y + 1]) + (gx[2, 2] * inputImage[x + 1, y + 1]);

                    int pixelY = (gy[0, 0] * inputImage[x - 1, y - 1]) + (gy[0, 1] * inputImage[x, y - 1]) + (gy[0, 2] * inputImage[x + 1, y - 1]) +
                                 (gy[1, 0] * inputImage[x - 1, y]) + (gy[1, 1] * inputImage[x, y]) + (gy[1, 2] * inputImage[x + 1, y]) +
                                 (gy[2, 0] * inputImage[x - 1, y + 1]) + (gy[2, 1] * inputImage[x, y + 1]) + (gy[2, 2] * inputImage[x + 1, y + 1]);

                    int pixel = (int)Math.Sqrt((pixelX * pixelX) + (pixelY * pixelY));

                    outputImage[x, y] = pixel;
                }
            }

            return outputImage;
        }
        public static int[,] BitmapImageToArray2D(BitmapImage src)
        {
            int[,] array2D = new int[src.PixelHeight, src.PixelWidth];

            WriteableBitmap wb = new WriteableBitmap(src);
            int width = wb.PixelWidth;
            int height = wb.PixelHeight;
            int bytesPerPixel = (wb.Format.BitsPerPixel + 7) / 8;
            int stride = wb.BackBufferStride;
            wb.Lock();
            unsafe
            {
                byte* pImgData = (byte*)wb.BackBuffer;
                int cRowStart = 0;
                int cColStart = 0;
                for (int row = 0; row < height; row++)
                {
                    cColStart = cRowStart;
                    for (int col = 0; col < width; col++)
                    {
                        byte* bPixel = pImgData + cColStart;
                        //bPixel[0] // Blue
                        //bPixel[1] // Green
                        //bPixel[2] // Red
                        int pixel = bPixel[2]; //Red
                        pixel = (pixel << 8) + bPixel[1]; //Green
                        pixel = (pixel << 8) + bPixel[0]; //Blue
                        array2D[row, col] = pixel;

                        cColStart += bytesPerPixel;
                    }
                    cRowStart += stride;
                }
            }
            wb.Unlock();
            wb.Freeze();

            return array2D;
        }
        public static WriteableBitmap Array2DToWriteableBitmap(int[,] array2D, BitmapImage src)
        {
            WriteableBitmap wb = new WriteableBitmap(src);
            int width = wb.PixelWidth;
            int height = wb.PixelHeight;
            int bytesPerPixel = (wb.Format.BitsPerPixel + 7) / 8;
            int stride = wb.BackBufferStride;
            wb.Lock();
            unsafe
            {
                byte* pImgData = (byte*)wb.BackBuffer;
                int cRowStart = 0;
                int cColStart = 0;
                for (int row = 0; row < height; row++)
                {
                    cColStart = cRowStart;
                    for (int col = 0; col < width; col++)
                    {
                        byte* bPixel = pImgData + cColStart;

                        bPixel[0] = (byte)((array2D[row, col] & 0xFF));// Blue
                        bPixel[1] = (byte)((array2D[row, col] & 0xFF00) >> 8);// Green
                        bPixel[2] = (byte)((array2D[row, col] & 0xFF0000) >> 16);// Red

                        cColStart += bytesPerPixel;
                    }
                    cRowStart += stride;
                }
            }
            wb.Unlock();
            wb.Freeze();

            return wb;
        }
        public static BitmapImage ConvertWriteableBitmapToBitmapImage(WriteableBitmap wbm)
        {
            BitmapImage bmImage = new BitmapImage();
            using (MemoryStream stream = new MemoryStream())
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(wbm));
                encoder.Save(stream);
                bmImage.BeginInit();
                bmImage.CacheOption = BitmapCacheOption.OnLoad;
                bmImage.StreamSource = stream;
                bmImage.EndInit();
                bmImage.Freeze();
            }
            return bmImage;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

    }
}
