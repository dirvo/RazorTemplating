﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExampleRazorTemplatesLibrary.Models;
using Razor.Templating.Core;

namespace ExampleConsoleApp.Net5_0
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                RazorTemplateEngine.Initialize();

                System.Console.WriteLine(DateTime.Now);
                var model = new ExampleModel()
                {
                    PlainText = "Some text",
                    HtmlContent = "<em>Some emphasized text</em>"
                };

                var viewData = new Dictionary<string, object>();
                viewData["Value1"] = "1";
                viewData["Value2"] = "2";

                var html = await RazorTemplateEngine.RenderAsync("/Views/ExampleView.cshtml", model, viewData);
                System.Console.Write(html);
                System.Console.WriteLine(DateTime.Now);


                // Render View with View Component
                html = await RazorTemplateEngine.RenderAsync("/Views/ExampleViewWithViewComponent.cshtml");
                System.Console.Write(html);
                System.Console.WriteLine(DateTime.Now);

                // Render View with Tag Helpers
                html = await RazorTemplateEngine.RenderAsync("/Views/ExampleViewWithTagHelpers.cshtml");
                System.Console.Write(html);
                System.Console.WriteLine(DateTime.Now);

            }
            catch (System.Exception e)
            {

                System.Console.WriteLine("{0}", e);
            }

            System.Console.ReadLine();
        }
    }
}