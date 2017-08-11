using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionLog transactionLog = new TransactionLog();
            TransactionLogProxy transactionLogProxy = new TransactionLogProxy(transactionLog);
            transactionLogProxy.RequestInfo();

            Console.ReadLine();
        }
    }

    internal interface ILog
    {
        void RequestInfo();
    }

    internal sealed class TransactionLog : ILog
    {
        public void RequestInfo()
        {
            Console.WriteLine("TransactionLog: Here is my data:");
            Console.WriteLine("1 - $10 000.00");
            Console.WriteLine("2 - $12 000.00");            
        }        
    }

    internal sealed class TransactionLogProxy : ILog
    {
        TransactionLog transactionLog;

        public TransactionLogProxy(TransactionLog transactionLog)
        {
            this.transactionLog = transactionLog;
        }

        public void RequestInfo()
        {
            Console.WriteLine("TransactionLogProxy: The Transaction Log was requested at {0}", DateTime.Now);
            transactionLog.RequestInfo();
        }
    }
}
