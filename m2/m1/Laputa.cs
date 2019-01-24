using System;
using WebSocketSharp;
using WebSocketSharp.Server;


namespace m1
{
    public class Laputa : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
       
            Console.WriteLine("ASDASD");
            MainClass.addVisit(e.Data);
            //Send(msg);
        }


        protected override void OnOpen()
        {
            base.OnOpen();
         
           
              
       }
    }

}