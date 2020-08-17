using System;

namespace JiYu{
    class ExceptionToConsole : Exception{
        private string messageToConsole;
        public ExceptionToConsole(string messageToConsole){
            this.messageToConsole = messageToConsole;
        }
        public override string ToString(){
            return this.messageToConsole;
        }
    }
}