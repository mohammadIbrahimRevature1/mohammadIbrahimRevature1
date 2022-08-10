﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;
namespace Httppractice
{
   class Program{
      static readonly HttpClient client = new HttpClient();
static async Task Main()
{
  // Call asynchronous network methods in a try/catch block to handle exceptions.
  try
  {
     HttpResponseMessage response = await client.GetAsync("http://api.icndb.com/jokes/random?limitTo=[nerdy] ");
     response.EnsureSuccessStatusCode();
     HttpResponseMessage rr = await client.GetAsync("http://api.icndb.com/jokes/random?exclude=Array");
    rr.EnsureSuccessStatusCode();
     string responseBody = await response.Content.ReadAsStringAsync();
     string rbody = await rr.Content.ReadAsStringAsync();
     System.Console.WriteLine(rbody);
     // Above three lines can be replaced with new helper method below
      //string responseBody = await client.GetStringAsync(uri);
     Console.WriteLine(responseBody);
  }
  catch(HttpRequestException e)
  {
     Console.WriteLine("\nException Caught!");
     Console.WriteLine("Message :{0} ",e.Message);
  }
}
   }
}