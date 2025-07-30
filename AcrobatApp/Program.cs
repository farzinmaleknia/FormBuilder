using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acrobat;
using System;
using System.Reflection;

namespace AcrobatApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AcroApp app = new AcroAppClass();
            AcroAVDoc avDoc = new AcroAVDocClass();


            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("avDoc type: " + avDoc.GetType().FullName);
            foreach (var method in avDoc.GetType().GetMethods())
            {
                Console.WriteLine(method.Name);
            }
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

            string inputPath = @"C:\Users\fa.maleknia\Desktop\MalekniaTest.pdf";
            string outputPath = @"C:\Users\fa.maleknia\Desktop\FilledOne.pdf";

            bool opened = avDoc.Open(inputPath, "MyDoc");
            if (!opened)
            {
                Console.WriteLine("❌ Failed to open file");
                return;
            }

            Console.WriteLine("✅ PDF opened");

            AcroPDDoc pdDoc = (AcroPDDoc)avDoc.GetPDDoc();

            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("pdDoc type: " + pdDoc?.GetType().FullName);
            foreach (var method in pdDoc.GetType().GetMethods())
            {
                Console.WriteLine(method.Name);
            }
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");



            dynamic jsObj = pdDoc.GetJSObject();
            jsObj.ExecuteThisJavaScript(" xfa.form.Schedule1.page1.subNo1.Table1.Row1.familyName.rawValue = 'Maleknia';");


            ////// Run JavaScript using reflection
            ////jsObj.GetType().InvokeMember(
            ////    "ExecuteJavaScript",
            ////    BindingFlags.InvokeMethod,
            ////    null,
            ////    jsObj,
            ////    new object[] {
            ////    "try { xfa.form.Schedule1.page1.subNo1.Table1.Row1.familyName.rawValue = 'Maleknia'; } catch (e) { app.alert('JS error: ' + e); }"
            ////    }
            ////);


            ////string js = @"try { xfa.form.Schedule1.page1.subNo1.Table1.Row1.familyName.rawValue = 'Maleknia'; } catch (e) { app.alert('JS error: ' + e); }";
            string js = @"try { console.println('farzin') } catch (e) { app.alert('JS error: ' + e); }";

            ////// Execute JavaScript using reflection (NOT dynamic!)
            ////app.GetType().InvokeMember(
            ////    "DoJavaScript",
            ////    BindingFlags.InvokeMethod,
            ////    null,
            ////    app,
            ////    new object[] { js }
            ////);

            System.Threading.Thread.Sleep(1000);





            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("jsObj type: " + jsObj?.GetType().FullName);
            foreach (var method in jsObj.GetType().GetMethods())
            {
                Console.WriteLine(method.Name);
            }
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");


            Console.WriteLine("✅ JavaScript executed");

            //AcroPDDoc pdDoc = (AcroPDDoc)avDoc.GetPDDoc();
            pdDoc.Save(1, outputPath);

            pdDoc.Close();
            avDoc.Close(1);
            app.Exit();

            Console.WriteLine("✅ PDF saved and Acrobat closed.");
        }
    }
}
