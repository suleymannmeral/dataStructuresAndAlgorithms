using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace takrar1
{
    internal class Program
    {
        static void Main(string[] args)
        {
                                            // tek yönlü doğrusal bağlı liste
            liste lst = new liste();       
            int sayi;
            int indis;

            int secim = menu();

            while(secim!=0)
            {
                switch(secim)
                {
                    case 1:
                        Console.Write("Eklenecek Sayı"); sayi=int.Parse(Console.ReadLine()); 
                        lst.basaekle(sayi); break;

                    case 2:
                        Console.Write("Eklenecek Sayı"); sayi = int.Parse(Console.ReadLine()); 
                        lst.sonaekle(sayi); break;

                        case 3:
                        Console.Write("Eklenecek Sayı"); sayi = int.Parse(Console.ReadLine());
                        Console.Write("İndis"); indis = int.Parse(Console.ReadLine());
                        lst.arayaekle(indis,sayi); break;

                        case 4:
                       
                        lst.bastansil(); break;

                        case 5:
                        lst.sondansil(); break;

                    case 6:
                        Console.Write("İndis"); indis = int.Parse(Console.ReadLine());
                        lst.aradansil(indis); break;

                        case 7:
                        lst.yazdir(); break;

                    case 8:
                        lst.elemansay(); break;

                    case 0:
                        break;

                    default: Console.WriteLine("hatalı girdi"); break;



                }
                secim = menu();
            }


            

            Console.ReadKey();





        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("1-Başa Ekle");
            Console.WriteLine("2-SOna Ekle");
            Console.WriteLine("3-Araya Ekle Ekle");
            Console.WriteLine("4-Baştan Sİl");
            Console.WriteLine("5-Sondan Sİl");
            Console.WriteLine("6-Aradan Sİl");
            Console.WriteLine("7-yazdır");
            Console.WriteLine("8-eleman sayısı");



            Console.WriteLine("0-Çıkış");
            Console.WriteLine("seçiminiz"); secim=int.Parse(Console.ReadLine());    
            return secim;

        }
    }

    class node
    {
        public int data;
        public node next;

        public node(int data)
        {
            this.data = data;
            next = null;
        }

    }
    class liste
    {
        node head; //baş düğümü oluşturduk

        public liste()
        {
            head = null;
        }

        public void basaekle(int data)
        {
            node eleman = new node(data);

            if(head==null)
            {
                head = eleman;
                Console.WriteLine("Başa Eleman Eklendi. Datası:"+eleman.data);
            }
            else
            {
                eleman.next = head;   // 30  10   20   
                head=eleman;
                Console.WriteLine("Listeye Eleman Eklendi. Datası:"+eleman.data);
            }


        }
        public void sonaekle(int data)

        {
            node eleman = new node(data);
            if (head == null)
            {
                head = eleman;
                Console.WriteLine("Başa Eleman Eklendi. Datası:" + eleman.data);
            }
            else
            {
                node temp = head;

                while(temp.next != null)    // 10  20   30 40
                {
                    temp= temp.next;

                }
                temp.next = eleman;
                Console.WriteLine("Sona Eleman Eklendi. Datası:"+eleman.data);

            }



        }
        public void arayaekle(int indis,int data)
        {
            node eleman = new node(data);

            if(head==null && indis==0)
            {
                head = eleman;
                Console.WriteLine("ary. Başa Eleman eklendi. Datası:"+eleman.data);
            }
            else if(head!=null &&  indis==0)
            {
                eleman.next = head;
                head=eleman;
                Console.WriteLine("ary 2. Başa Eleman eklendi. Datası:" + eleman.data);
            }
            else
            {
                int i = 0;
                node temp= head;
                node tempinoncesi= temp;      // 10   20to     30t   40 
                while(temp.next!=null)
                {
                    if (i == indis)
                    {
                        tempinoncesi.next = eleman;
                        eleman.next = temp;
                        i++;
                        break;

                    }
                    tempinoncesi = temp;
                    temp = temp.next;
                    i++;

                }
                if (i == indis)
                {
                    tempinoncesi.next = eleman;
                    eleman.next = temp;
                    

                }
                if(temp.next==null && i+1==indis)
                {
                    sonaekle(data);
                }
            }

        }

        public void bastansil()
        {
            if(head==null)
            {
                Console.WriteLine("Liste Boş");
            }
            if(head.next==null)
            {
                Console.WriteLine("Listedeki tek düğüm silindi. datası:" + head.data);
                head = null;
            }

            else
            {
                head = head.next;
                Console.WriteLine("Baştaki Düğüm Sİllindi. ");

            }
        }

        public void sondansil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste Boş");
            }
            if (head.next == null)
            {
                Console.WriteLine("Listedeki tek düğüm silindi. datası:" + head.data);
                head = null;
            }
            else
            {
                node temp = head;
                node tempinoncesi=temp;
                while(temp.next!=null)           // 10  20  30to  40t
                {
                    tempinoncesi = temp;
                    temp=temp.next;

                }
                tempinoncesi.next=null;
                Console.WriteLine("Sondaki Eleman Sİlindi");

            }

        }
        public void aradansil(int indis)
        {
            if (head == null && indis==0)
            {
                Console.WriteLine("Liste Boş");
            }
            else if (head.next == null && indis == 0)
            {
                
                head = null;
                Console.WriteLine("Listede Kalan Son Elemanı Sildiniz");
            }
            else if (head.next != null && indis == 0)
            {
                bastansil();
              
               
            }

            else

            {
                int i = 0;
                node temp = head;
                node temp2= temp;
                while(temp.next!=null)
                {
                    if(i==indis)              // 10t2  20t  30 
                    {
                        temp2.next = temp.next;
                        Console.WriteLine("Aradan silindi");
                        i++;
                        break;


                    }
                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }
                if (i == indis)              // 10t2  20t  30 
                {
                    temp2.next = temp.next;
                    Console.WriteLine("Aradan silindi");
                
                }
                if(temp.next==null && i+1==indis)
                {
                    sondansil();
                }

            }

        }

        public void yazdir()
        {
            if(head==null)
            {
                Console.WriteLine("Liste boş");
            }
            node temp = head;
            Console.Write("Baş-->");
            while (temp.next!=null)          // 10  20  30  
            {
                Console.Write(+temp.data + "-->");
                temp =temp.next;
              

            }
            Console.Write(+temp.data + "--> Son");


        }

        public void elemansay()
        {
            int i = 0;
            node temp= head;
            if(head==null)
            {
                Console.WriteLine("Eleman sayısı:"+i);
            }
            while( temp.next!=null)           // 10  20t  30t  40t  50t   4
            {
                i++;
                temp= temp.next;

            }
            i++;
            Console.Write("Elemasn sayısı:"+i);



        }
    }
}
