HttpClient client = new HttpClient();

// Call asynchronous network methods in a try/catch block to handle exceptions.
try	
{
    string responseBody = await client.GetStringAsync("http://simpleapi:7001/Home");
    Console.WriteLine(responseBody);
}
catch(HttpRequestException e)
{
    Console.WriteLine("\nException Caught!");	
    Console.WriteLine("Message :{0} ",e.Message);
}