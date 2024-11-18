namespace MyApp
{
    public class WebPage
    {

        Stack<string> browser = new Stack<string>();

        public  string Url { get; set; }

        public WebPage()
        {
            Url = "";
        }

        public void Back()
        {
            browser.Pop();
            Url = browser.Peek();


        }

        public void openNewPage()
        {

            browser.Push(Url);

 

        }  
        
        public void currntPage()
        {


            Console.WriteLine($"currnt page {Url}");

        }
    }
}