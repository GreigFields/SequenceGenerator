using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SequenceGeneratorWeb.Models;
using System.Diagnostics;
using SequenceGeneratorLib;
using System;
using PrimesLib;
/* This controller calls all of the sequence generators as well as options in the Fibonacci generator that optimize the performance
 * of that generator.
 */
namespace SequenceGeneratorWeb.Controllers
{
    public class GeneratorController : Controller
    {
        static int Status = 0;
        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Index(string value, GeneratorModel P)
        {
            
            // This Action method is somewhat like a Factory using the model name and attaching the correct method to the interface 
            
            if(Status== 1)
            {
                Status = 0;
                return View();
            }
            int  InputValue = P.StartingValue;
            string mod = P.modelID;
            ISequenceGenerator sequenceGenerator;
            long[] sequencevalues =new long[0];
            DateTime dtStart;
            TimeSpan ts = new TimeSpan();
            switch (mod) 
            {
                case "0":  // Liebniz Sequence
                    LiebnizSequenceGenerator lsg = new LiebnizSequenceGenerator();
                    sequenceGenerator = lsg;
                    double[]  dsequencevalues;
                    dsequencevalues = lsg.ListOfTerms(Convert.ToInt32(InputValue));
                    ViewBag.OutputSequence = "";
                    for (int i = 0; i < dsequencevalues.Length; i++) // Special printing required for Liebniz Sequence so done in case "0"
                    {
                        string s = "";
                        if (i > 0 && dsequencevalues[i] < 0)
                            s = " -";
                        else if (i > 0)
                            s = " +";
                        
                        ViewBag.OutputSequence += s + " 1/" + (1 / Math.Abs(dsequencevalues[i])).ToString("0");
                    }
                    ViewBag.OutputSequence += " Sum Should Approach Pi/4 = " + (Math.PI / 4).ToString("0.000000");
                    break;

                case "1": // Primes Sequence
                    PrimesSequenceGenerator psg = new PrimesSequenceGenerator();
                    sequenceGenerator = psg;
                    sequencevalues = psg.ListOfTerms(Convert.ToInt32(InputValue));
                    break;
                
                case "2": // Fibonacci Sequence
                    FibonacciSequenceGenerator fsg = new FibonacciSequenceGenerator();
                    sequenceGenerator = fsg;
                    sequencevalues = fsg.ListOfTerms(Convert.ToInt32(InputValue)); // Added List of Terms (Should be in a factory)
                    break;
                
                case "3": // Fibonacci Performance Test
                    FibonacciSequenceGenerator ffsg = new FibonacciSequenceGenerator();
                    sequenceGenerator = ffsg;
                    sequencevalues = ffsg.ListOfTermsForLong(Convert.ToInt32(InputValue));// Added List of Terms (Should be in a factory)
                    dtStart = DateTime.Now;
                    ViewBag.OutputResult = ffsg.GenerateNthTermForLong(Convert.ToInt32(InputValue)).ToString("0.000000");
                    ViewBag.OutputSum = ffsg.SumOfTermsForLong(Convert.ToInt32(InputValue)).ToString("0.000000");
                    DateTime dtEnd = DateTime.Now;
                    ts = dtEnd.Subtract(dtStart);
                    break;
                
                default:
                    return View();
            }
            Status = 1;
            
            if (mod != "3") // Special Case for Performance testing needed to do the timing and other methods in the case 3 switch code
            {
                dtStart = DateTime.Now;
                ViewBag.OutputResult = sequenceGenerator.GenerateNthTerm(Convert.ToInt32(InputValue)).ToString("0.000000"); // Note Interface can be used for all sequences except the test
                ViewBag.OutputSum = sequenceGenerator.SumOfTerms(Convert.ToInt32(InputValue)).ToString("0.000000");
                DateTime dtEnd = DateTime.Now;
                ts = dtEnd.Subtract(dtStart);
            }
            if (mod != "0")
            {
                ViewBag.OutputSequence = "";
                for (int i = 0; i < sequencevalues.Length; i++)
                {
                    ViewBag.OutputSequence += ", " + sequencevalues[i];
                }
            }
            ViewBag.ExecutionTime = ts.Seconds +" secs " + ts.Milliseconds + " msecs";
            Status = 0;
            return View();
        }
    }
}
