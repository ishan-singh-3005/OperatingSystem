using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatingSystem.Compressor
{
    public class FileCompressor
    {
        public HuffmanTree huffmanTree;
        public string message;

        public FileCompressor()
        {
            this.huffmanTree = new HuffmanTree();
        }

        public void CompressTextFile(string filePath, string binFilePath, string codingSchemePath)
        {
            //Read the text file in string variable
            string inputFile = File.ReadAllText(filePath);

            // Build the Huffman tree
            huffmanTree.buildTree(inputFile);

            // Encode the input file in BitArray in binary form
            BitArray bit_array = huffmanTree.Encode(inputFile);

            // Byte array for storing the bits from BitArray to save in bin file
            byte[] bytes = new byte[bit_array.Length / 8 + (bit_array.Length % 8 == 0 ? 0 : 1)];
            bit_array.CopyTo(bytes, 0);

            // write all the bits from byte array in bin file
            File.WriteAllBytes(binFilePath, bytes);
            message = "Text File Encoded Successfully";
            Console.WriteLine(message);

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < bit_array.Count; i++)
            {
                char bitChar = bit_array[i] ? '1' : '0';
                stringBuilder.Append(bitChar);
            }
            var stringBuilder2 = stringBuilder.ToString();
            File.WriteAllText(codingSchemePath, stringBuilder2);
            message = "Coding Scheme File Created Successfully";
            Console.WriteLine(message);

        }
    }
}
