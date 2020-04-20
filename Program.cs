using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTEGER_to_Number_reader
{
     class Program
    {

        #region static declarations
        static Hashtable units;
        static Hashtable tens;
        static Hashtable ten;
        #endregion

        static void Main(string[] args)
        {
            bool endofapp = true;
            while (endofapp)
            {
                #region units
                units = new Hashtable();
                units.Add("0", "");
                units.Add("1", "One");
                units.Add("2", "Two");
                units.Add("3", "Three");
                units.Add("4", "Four");
                units.Add("5", "Five");
                units.Add("6", "six");
                units.Add("7", "Seven");
                units.Add("8", "Eight");
                units.Add("9", "Nine");
                #endregion

                #region ten
                ten = new Hashtable();
                // ten.Add("0", "");
                ten.Add("10", "ten");
                ten.Add("11", "eleven");
                ten.Add("12", "Twelve");
                ten.Add("13", "Thirteen");
                ten.Add("14", "Fourteen");
                ten.Add("15", "Fifteen");
                ten.Add("16", "sixteen");
                ten.Add("17", "Seventeen");
                ten.Add("18", "Eightteen");
                ten.Add("19", "Nineteen");
                #endregion

                #region tens
                tens = new Hashtable();
                tens.Add("0", "");
                tens.Add("1", "ten");
                tens.Add("2", "Twenty");
                tens.Add("3", "Thirty");
                tens.Add("4", "Fourty");
                tens.Add("5", "Fifty");
                tens.Add("6", "sixty");
                tens.Add("7", "seventy");
                tens.Add("8", "eighty");
                tens.Add("9", "ninenty");
                #endregion

                Console.WriteLine("Please input in a Number");
                string number = Console.ReadLine();
              
                try
                {
                    double.Parse(number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;

                }
                #region intger Checkers
                int noOfBillion = 8;
                int noHundredOfThousand = 6;
                int noTensofThousand = 5;
                int noThousValue = 4;
                int noMillVal = 7;
                int noHundred = 3;
                int noTen = 2;
                int noUnit = 1;

                #endregion
                #region checktypeofnumber
                //for thousand
                if (number.Length == noThousValue)
                {
                    Console.WriteLine(Thousandtype(number));
                }
                //for million
                if (number.Length == noMillVal)
                {
                    Console.WriteLine(MillionType(number));
                }
                //for Hundred
                if (number.Length == noHundred)
                {
                    Console.WriteLine(Hundred(number));
                }
                //for ten and tents
                if (number.Length == noTen)
                {
                    Console.WriteLine(tenthsnumber(number));
                }
                //for Units
                if (number.Length == noUnit)
                {
                    Console.WriteLine(unitNumber(number));
                }
                //for tens of thousand
                if(number.Length==noTensofThousand)
                {
                    Console.WriteLine(Tensofthousand(number));
                }

                if(number.Length==noHundredOfThousand)
                {
                    Console.WriteLine(HundredsOfThousand(number));
                }
                #endregion

             
                
            }
        }


        #region method converters
        public static string unitNumber(string number)
        {
            StringBuilder sb = new StringBuilder();
            if(number[0]!='0')
            {
                sb.Append(units[number[0].ToString()]);
            }
            else if(number[0]=='0')
            {
                sb.Append("Zero");
            }
            return sb.ToString();
            
        }

        public static string tenthsnumber(string number)
        {
            StringBuilder sb = new StringBuilder();
            if (double.Parse(number) <= 19)
            {
                sb.Append(ten[number].ToString() as string);
            }
            else if (double.Parse(number) > 19)
            {
                sb.Append(tens[number[0].ToString()] as string +" ");
                sb.Append(units[number[1].ToString()] as string);

            }
            return sb.ToString();

        }

          public static string Thousandtype (string number)
          {
            StringBuilder sb = new StringBuilder();


            int nothousand = 4;


            if (number.Length == nothousand)
            {
                
                if ((number.Length == nothousand) && (number[1] != '0'))
                {
                    sb = new StringBuilder();
                    sb.Append(units[number[0].ToString()] as string + " " + "Thousand ");
                    sb.Append(units[number[1].ToString()] as string + " " + "Hundred And" + " ");
                    sb.Append(tens[number[2].ToString()] as string + " ");
                    sb.Append(units[number[3].ToString()] as string + " ");


                   

                }

                else if ((number.Length == nothousand) && (number[1] == '0'))
                {
                    sb = new StringBuilder();
                    sb.Append(units[number[0].ToString()] as string + " " );
                    sb.Append(units[number[1].ToString()] as string + " ");
                    sb.Append(tens[number[2].ToString()] as string + " ");
                    sb.Append(units[number[3].ToString()] as string + " ");
                   
                }
            }
            return sb.ToString();


        }
        public static string MillionType(string number)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append(units[number[0].ToString()] as string + " " + "million");
            number = number.Remove(0, 1);
            sb.Append(HundredAndforMill(number));
            number = number.Remove(0, 1);
            sb.Append(TenthForMill(number));
            number = number.Remove(0, 1);
            sb.Append(Thousandtype(number));
            return sb.ToString();


        }

        public static string HundredAndforMill(string number)
        {
            const int HMtest = 6;
            StringBuilder sb = new StringBuilder();
            if (number.Length == HMtest && number[0] != '0')
            {
                sb.Append(units[number[0].ToString()] as string + " " + "Hundred And");
            }
            else if  (number.Length == HMtest && number[0]=='0')
            {
                sb.Append(" ");
            }
            return sb.ToString();
        }

        public static string TenthForMill(string number)
        {
            const int HMtest = 5;
            StringBuilder sb = new StringBuilder();
            if (number.Length == HMtest && number[0] != '0')
            {
                sb.Append(tens[number[0].ToString()] as string + " " );
            }
            else if (number.Length == HMtest && number[0] == '0')
            {
                sb.Append(" ");
            }
            return sb.ToString();
        }

        public static string Hundred(string number)
        {
            StringBuilder sb = new StringBuilder();

            if((number[1]!='0') && (number[2]!='0'))
            {
                sb.Append(units[number[0].ToString()] as string + "  " + " Hundred  and ");
                sb.Append(tens[number[1].ToString()] as string + "  ");
                sb.Append(units[number[2].ToString()] as string);
            }

            else if ((number[1] == '0') && (number[2] == '0'))
            {
                sb.Append(units[number[0].ToString()] as string  + " Hundred ");
            }
           else  if ((number[0] == '0') && (number[1] != '0'))
            {
                sb.Append(tens[number[1].ToString()] as string + "  ");
                sb.Append(units[number[2].ToString()] as string);
            }


            return sb.ToString();
        }

        public static string Tensofthousand(string number)
        {
            StringBuilder sb = new StringBuilder();
            if(double.Parse(number[0].ToString()) > 1)
            {
                sb.Append(tens[number[0].ToString()] as string+" ");
                sb.Append(units[number[1].ToString()] as string+" "+" Thousand "+"  ");
                number = number.Remove(0, 2);
                sb.Append(" " +Hundred(number));

            }
            else if(double.Parse(number[0].ToString())==1)
            {
                StringBuilder CAppendfor2no = new StringBuilder();
                CAppendfor2no.Append(number[0].ToString());
                CAppendfor2no.Append(number[1].ToString());
                sb.Append(tenthsnumber(CAppendfor2no.ToString()) as string + " thousand");           
                number = number.Remove(0, 2);
                sb.Append(Hundred(number));

            }

            return sb.ToString();
        }
        public static string HundredsOfThousand(string number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(units[number[0].ToString()] as string + " Hundred and ");
            number = number.Remove(0, 1);
            sb.Append(Tensofthousand(number));

            return sb.ToString();
        }
        public static string BillionConv(string number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(units[number[0].ToString()] as string);
            StringBuilder forhun = new StringBuilder();
            return null;

        }
        #endregion
    }
}
