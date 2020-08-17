using System;

namespace JiYu{
    class JiYuConsole{
        private static string[] getSplittedWords(string originStr){
            bool isInQuotes = false;
            string currentWord = "";
            string[] result = new string[64];
            int cnt = 0;
            originStr = originStr + " ";
            for(int i=0; i<originStr.Length; i++){
                if(cnt > 63){
                    break;
                }
                if(originStr[i] == '\"'){
                    if(i > 0 && originStr[i-1] != '\\') isInQuotes = !isInQuotes;
                    else currentWord = currentWord + originStr[i];
                }else if((!isInQuotes) && originStr[i] == ' '){
                    if(currentWord != "") result[cnt++] = currentWord;
                    currentWord = "";
                }else{
                    currentWord = currentWord + originStr[i];
                }
            }
            return getSubSequence(result, 0, cnt);
        }
        private static string getChangedDir(string originDir, string newDir){
            string result = originDir;
            if(!newDir.EndsWith("/")) newDir = newDir.Trim() + "/";
            if(newDir == "/" || newDir == "~/") result =  "/thispc/" + System.IO.Directory
                                                        .GetCurrentDirectory().Replace("\\", "/").ToLower();
            else if(newDir.StartsWith("/")) result = newDir;
            else{
                while(newDir.StartsWith("../")){
                    newDir = newDir.Substring(3);
                    originDir = originDir.Remove(originDir.LastIndexOf("/"));
                }
                result = originDir + "/" + newDir;                
            }
            while(result.EndsWith("/")) result = result.Remove(result.Length - 1);
            return result;
        }
        private static void printUsages(){
            Console.WriteLine("Usage: ");
        }
        private static void printCopyrights(){
            Console.WriteLine("JiYu - the - hack      version 0.0.1");
            Console.WriteLine("Copyright (C) yaoxi_std. All rights reserved.\n");
            Console.WriteLine("This program is provided as a tool to control your classmates' computers");
            Console.WriteLine("using the leaks in Mythware JiYu.\n");
            Console.WriteLine("If you want, please donate me on GitHub at");
            Console.WriteLine("'https://github.com/yaoxi-std/JiYu-the-hack'.\n");
        }
        private static string[] getSubSequence(string[] source, int beginIndex, int endIndex){
            if(endIndex == -1) endIndex = source.Length;
            string[] result = new string[endIndex - beginIndex];
            for(int i=beginIndex; i<endIndex; i++) result[i-beginIndex] = source[i];
            return result;
        }
        public static void Main(string[] args){
            printCopyrights();
            string currentDir = "/thispc/" + System.IO.Directory.GetCurrentDirectory()
                                                                .Replace("\\", "/").ToLower();
            while(true){
                Console.Write(currentDir + ">> ");
                string commandLine = Console.ReadLine();
                string[] commands = getSplittedWords(commandLine);
                if(commands.Length == 0) continue;
                if(commands[0] == "exit") break;
                try{
                    switch (commands[0]){
                        case "cd":
                        case "changedir":
                            currentDir = getChangedDir(currentDir, commands[1]);
                            break;
                        case "exe":
                        case "execute":
                            HackAPI.execute(
                                commands[1], 
                                String.Join(" ", getSubSequence(commands, 2, commands.Length))
                            );
                            break;
                        case "cp":
                        case "copy":
                            HackAPI.copy(new CopyStatement(
                                commands[1],
                                commands[2]
                            ));
                            break;
                        case "help":
                            printUsages();
                            break;
                        default:
                            Console.WriteLine("Unknown command. Type 'help' for help.");
                            printUsages();
                            break;
                    }                    
                }catch(IndexOutOfRangeException){
                    Console.WriteLine("ERROR: Too few index!");
                }catch(Exception e){
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}