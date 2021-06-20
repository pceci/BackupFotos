using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace BackupFotos
{
    public class cPrimerosPasosFotos
    {
        public static void test()
        {
            try
            {
                string ruta = @"C:\DB\Google Fotos\Photos from 2021";//Photos from 2018 @"C:\DB\Google Fotos\test2";//
                string rutaMover = @"C:\DB\Google Fotos\testFotos";//@"C:\DB\Google Fotos\llll";//
                if (Directory.Exists(ruta))
                {
                    DirectoryInfo di = new DirectoryInfo(ruta);
                    foreach (var fi in di.GetFiles())
                    {
                        if (fi.Extension == ".jpg" || fi.Extension == ".jpeg")
                        {
                            if (isCamara(Path.Combine(ruta, fi.Name)))
                            {
                                //Console.WriteLine("Archivo original: " + Path.Combine(ruta, fi.Name));
                                if (File.Exists(Path.Combine(ruta, fi.Name)) &&
                                !File.Exists(Path.Combine(rutaMover, fi.Name)))
                                {
                                    Console.WriteLine("Archivo copiado: " + Path.Combine(rutaMover, fi.Name));
                                    File.Copy(Path.Combine(ruta, fi.Name), Path.Combine(rutaMover, fi.Name));
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No existe path: " + ruta);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private static bool isCamara(string pPathAndFile)
        {
            bool result = false;
            Image theImage = new Bitmap(pPathAndFile);
            PropertyItem[] propItems = theImage.PropertyItems;
            int count_bool = 0;
            foreach (PropertyItem propItem in propItems)
            {
                if (propItem.Value != null && (propItem.Id.ToString("x").ToUpper() == "10F" || propItem.Id.ToString("x").ToUpper() == "110"))
                {
                    switch (Encoding.UTF8.GetString(propItem.Value, 0, propItem.Value.Length - 1))
                    {
                        case "Xiaomi":
                        case "Mi A1":
                        case "motorola":
                        case "motorola one":
                        case "Moto G (5)":
                            count_bool++;
                            break;
                        default:
                            break;
                    }
                }
            }
            if (count_bool > 1)
            {
                result = true;
            }
            return result;
        }
    }
}