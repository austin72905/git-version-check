﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperateCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = false;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine("dotnet --version");
            p.StandardInput.WriteLine("dotnet --version");
            p.StandardInput.WriteLine("dotnet --version");
            p.StandardInput.WriteLine("dotnet --version");
            p.StandardInput.WriteLine("dotnet --version");
            p.StandardInput.WriteLine("dotnet --version");

            //获取cmd窗口的输出信息
            StreamReader reader = p.StandardOutput;

            p.StandardInput.AutoFlush = true;
            p.StandardInput.WriteLine("exit");
            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
            




            string result = reader.ReadToEnd(); //會打印整個console 的訊息，包括聲明那些
            var tempdotversion = result.Split(' ');
            var dotversion=tempdotversion[8].Split(new char[2] { '\r','\n' });
            var dotversion1 = tempdotversion[9].Split(new char[2] { '\r', '\n' });
            Console.WriteLine($"ouput = {dotversion[2]} and {dotversion1[2]}");
            Console.ReadKey();
            
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令

            
            
            //Console.ReadKey();

        }
    }
}
