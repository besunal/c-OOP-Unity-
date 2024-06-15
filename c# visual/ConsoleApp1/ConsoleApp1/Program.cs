using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector V0 = new Vector(1, 2, 3);
            Vector V1 = new Vector(1, 2, 4);


            Vector zero = new Vector();
            //bu zero vektorunu kopyalamak istersek
            Vector compyofV1 = new Vector(V1);

            // scale vector
            V1.Scale(5);
            //unitiliation/ unit vector/ normalization
            
            //unitize
            if(V1.Unitize() == true)
            {
                Console.WriteLine("success.");
            }
            //vector addition
            V1.AddVector(zero);
            


            Console.WriteLine(V1.GetLength());

            double dot = Vector.dotProduct(V0, V1);


           
        }

        public class Vector
        {
            public double X { get; set; }
            public double Y { get; set; }
            public double Z { get; set; }

            public static Vector Xaxis
            {
                get => new Vector(1, 0, 0);
            }
            public static Vector Yaxis
            {
                get => new Vector(0, 1, 0);
            }

            public static Vector Zaxis
            {
                get => new Vector(0, 0, 1);
            }

            public double Length
            {
                get
                {
                    return GetLength();
                }
            }

            //constructors
            public Vector()
            {
                this.X = 0;
                this.Y = 0;
                this.Z = 0;
            }
            public Vector(double x, double y, double z)
            {
                this.X = x;
                this.Y = y;
                this.Z = z;
            }

            public Vector(Vector other)
            {
                this.X = other.X;
                this.Y = other.Y;
                this.Z = other.Z;
            }

            //methods
            public double GetLength()
            {
                double sql = this.X * this.X + this.Y * this.Y + this.Z * this.Z;
                double len = Math.Sqrt(sql);
                return len;
            }
            // change orientation.
            public void Reverse()
            {
                this.X = -this.X;
                this.Y = -this.Y;
                this.Z = -this.Z;
            }
            //scaling vectors
            public void Scale(double factor)
            {
                this.X *= factor;
                this.Y *= factor;
                this.Z *= factor;
            }

            //normalization vector 1 unit vector
            public bool Unitize()
            {
                double len = this.GetLength();
                if (len <= 0)
                {
                    return false;
                }
                this.X /= len;
                this.Y /= len;
                this.Z /= len;
                return true;
            }

             public void AddVector(Vector other)
            {
                this.X += other.X;
                this.Y += other.Y;
                this.Z += other.Z;
            }
             //operator overloads
             public static  Vector operator +(Vector a, Vector b)
            {
                return Vector.Addition(a, b);
            }

            public static  double  operator *(Vector a, Vector b)
            {
                return Vector.dotProduct(a,b);
            }



            //static method
            public static Vector Addition(Vector a,Vector b)
            {
                double newX=a.X + b.X;
                double newY=a.Y + b.Y;
                double newZ=a.Z + b.Z;
                Vector v=new Vector(newX,newY,newZ);
                return v;
            }

            public static double dotProduct(Vector a,Vector b)
            {
               return  a.X + b.X + a.Y + b.Y + a.Z + b.Z;
               
            }
            //cross product
            public static  Vector CrossProduct(Vector a,Vector b)
            {
                double x=a.Y * b.Z - a.Z * b.Y;
                double y=a.Z * b.X - a.X * b.Z;
                double z=a.X * b.Y - a.Y * b.X;
                return new Vector(x, y, z);
            }


            public override string ToString()
            {
                return $"[{X},{Y},{Z}]";


            }

        }
    }
}