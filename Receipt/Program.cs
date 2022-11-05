

using Newtonsoft.Json;
using Receipt;

string url = "https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1";

HttpClient client = new HttpClient();

try
{
    var responce = await client.GetAsync(url);
    string JsonResponce = await responce.Content.ReadAsStringAsync();
    //Console.WriteLine(JsonResponce);

    var mypost = JsonConvert.DeserializeObject<Root[]>(JsonResponce);

    //foreach (var item in mypost)
    //{

    //	//Console.WriteLine(item.price);

    //	var querry=from item.
    //}

    double totalDomestic = 0;
    double totalInternational = 0;
    int countDomestic = 0;
    int countInternational = 0;

    var groupByOriginDomestic =
    (from post in mypost
     where post.domestic.Equals(true)
     select post).OrderBy(x => x.name);

    Console.WriteLine("________________________Products____________________________");



    Console.WriteLine("------------------------Domestic----------------------------");

    foreach (var group in groupByOriginDomestic)
    {


        if (group.weight == 0)
        {
            group.weight.ToString().Replace("0", "N/A");

        }


        Console.WriteLine($" \n {group.name}\n {group.price}$ \n {group.description} \n Weight {group.weight}g");

        totalDomestic += (double)group.price;
        countDomestic++;
    }

    var groupByOriginInernational =
   (from post in mypost
    where post.domestic.Equals(false)
    select post).OrderBy(x => x.name);



    Console.WriteLine("------------------------International----------------------------");

    foreach (var group in groupByOriginInernational)
    {

        if (group.weight == 0)
        {
            group.weight.ToString().Replace("0", "N/A");

        }

        Console.WriteLine($" \n {group.name}\n {group.price}$ \n {group.description} \n Weight {group.weight}g");

        totalInternational += (double)group.price;
        countInternational++;
    }

    Console.WriteLine($"The Domestic cost is: {totalDomestic} \n The International cost is: {totalInternational} \n the Domestic count: {countDomestic} \n the International count: {countInternational}");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    throw;
}
finally
{
    client.Dispose();
}