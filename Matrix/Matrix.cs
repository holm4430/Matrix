//Author: Kevin Holmes
//Date: March 7, 2015
//Description: Basic matrix class implementation
//Methods Include: add, subtract, multiply, transpose

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixWork
{
    public class Matrix
    {

        private double[,] data;
        private int rows;
        private int cols;

        public Matrix(int row, int col)
        {   rows = row;
            cols = col;
            data = new double[row,col];
       
        }

        //Performs Matrix Addition
        public Matrix Add(Matrix m)
        {
            int i = 0;
            int j = 0;
            if (this.data.GetLength(0) != m.data.GetLength(0) || this.data.GetLength(1) != m.data.GetLength(1))
            {
                Console.WriteLine("Matrix dimensions do not match");
                Environment.Exit(1);
            }

            Matrix result = new Matrix(m.data.GetLength(0), m.data.GetLength(1));


            for (i = 0; i < this.data.GetLength(0); i++)
            {
                for (j = 0; j < this.data.GetLength(1); j++)
                {
                    result.SetElement(this.data[i,j] + m.data[i,j], i, j);

                }

            }
            return result;

        }


        //Performs Matrix Multiplication
        public Matrix Multiply(Matrix m)
        {
          
            if (this.data.GetLength(1) != m.data.GetLength(0))
            {
                Console.WriteLine("Inner matrix dimensions do not match");
                Environment.Exit(1);
            }
            Matrix result = new Matrix(this.data.GetLength(0), m.data.GetLength(1));
   	        for(int i = 0;i < result.data.GetLength(0);i++)
			{
				for(int j = 0;j< result.data.GetLength(1);j++)
				{
					result.data[i,j]=0;
					for(int k = 0; k < this.data.GetLength(1);k++) 
					    result.data[i,j] = result.data[i,j]+this.data[i,k]*m.data[k,j];
				}
			}
            
            return result;
        }


        //Performs Matrix Transpose
        public Matrix Transpose()
        {   Matrix result = new Matrix(this.data.GetLength(1),this.data.GetLength(0));
            int i = 0;
            int j = 0;

            for (i = 0; i < cols; i++)
            {
                for (j = 0; j < rows; j++)
                {
                    result.data[j, i] = this.data[i, j];
                }
            }
                return result;
        }

        //Performs Matrix Subtraction
        public Matrix Subtract(Matrix m)
        {
            int i = 0;
            int j = 0;
            if (this.data.GetLength(0) != m.data.GetLength(0) || this.data.GetLength(1) != m.data.GetLength(1))
            {
                Console.WriteLine("Matrix dimensions do not match");
                Environment.Exit(1);
            }

            Matrix result = new Matrix(m.data.GetLength(0), m.data.GetLength(1));


            for (i = 0; i < this.data.GetLength(0); i++)
            {
                for (j = 0; j < this.data.GetLength(1); j++)
                {
                    result.SetElement(this.data[i,j] - m.data[i,j], i, j);

                }

            }
            return result;

        }

        //Implements Matrix Scalar Multiplication
        public void ScalarMultiply(double scalar)
        {
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    this.data[i, j] = this.data[i, j] * scalar;
                }
            }

        }




        //getter
        public double GetElement(int row, int col)
        {
            double element;

            element = this.data[row,col];

            return element;
        }

        //setter
        public void SetElement(double value, int row, int col)
        {
            this.data[row,col] = value;

        }

        public override string ToString()
        {
            string result = "";
            int i = 0;
            int j = 0;

            for (i = 0; i < this.rows; i++)
            {
                result = result + "\n";
                for (j = 0; j < this.cols; j++)
                {
                    result = result + "     " + this.GetElement(i, j).ToString();
                }
            }

            return result;

        }


    }
}
