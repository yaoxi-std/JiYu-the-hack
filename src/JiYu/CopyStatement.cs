using System;

namespace JiYu{
    class CopyStatement{
        private string fromFile, toFile;
        private bool fromFileOnThisPC, toFileOnThisPC;
        private CopyStatement(
            string fromFile, string toFile, 
            bool fromFileOnThisPC, bool toFileOnThisPC
        ){
            this.fromFile = fromFile;
            this.toFile = toFile;
            this.fromFileOnThisPC = fromFileOnThisPC;
            this.toFileOnThisPC = toFileOnThisPC;
        }
        public CopyStatement(
            string fromFile, string toFile
        ){
            try{
                this.fromFile = fromFile.Substring(fromFile.IndexOf("/", fromFile.IndexOf("/") + 1));
            }catch(ArgumentOutOfRangeException){
                throw new ExceptionToConsole("ERROR: '" + fromFile + "' is not an available directory!");
            }
            try{
                this.toFile = toFile.Substring(toFile.IndexOf("/", toFile.IndexOf("/") + 1));     
            }catch(ArgumentOutOfRangeException){
                throw new ExceptionToConsole("ERROR: '" + toFile + "' is not an available directory!");
            }
            this.fromFileOnThisPC = fromFile.StartsWith("/thispc/");
            this.toFileOnThisPC = toFile.StartsWith("/thispc/");
        }
        private void setFromFile(string fromFile, bool fromFileOnThisPC){
            this.fromFile = fromFile;
            this.fromFileOnThisPC = fromFileOnThisPC;
        }
        private void setToFile(string toFile, bool toFileOnThisPC){
            this.toFile = toFile;
            this.toFileOnThisPC = toFileOnThisPC;
        }
        public void setFromFile(string fromFile){
            try{
                this.setFromFile(
                    fromFile.Substring(fromFile.IndexOf("/", fromFile.IndexOf("/") + 1)),
                    fromFile.StartsWith("/thispc/")
                );                
            }catch(ArgumentOutOfRangeException){
                throw new ExceptionToConsole("ERROR: '" + fromFile + "' is not an available directory!");
            }
        }
        public void setToFile(string toFile){
            try{
                this.setFromFile(
                    toFile.Substring(toFile.IndexOf("/", toFile.IndexOf("/") + 1)),
                    toFile.StartsWith("/thispc/")
                );
            }catch(ArgumentOutOfRangeException){
                throw new ExceptionToConsole("ERROR: '" + toFile + "' is not an available directory!");
            }
        }
        public string getFromFile(){
            return this.fromFile;
        }
        public string getToFile(){
            return this.toFile;
        }
        public bool isFromFileOnThisPC(){
            return fromFileOnThisPC;
        }
        public bool isToFileOnThisPC(){
            return toFileOnThisPC;
        }
    }
}