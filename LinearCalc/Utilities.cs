using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using Microsoft.Win32;
using LinearCalc;

namespace Utilities
{
    public enum manufactoryList { RENISHAW, API};

    public enum infoText
    {
        NONE,
        FILE_CONTENT_ERROR,
        FILE_FORMAT_ERROR,
        DATA_OVERSIZE_ERROR,
        DATA_FORMAT_ERROR,
        FILE_SAVE_COMPLETE,
        FILE_SAVE_ERROR,
        FILE_OPEN_ERROR       
    }

    public enum varNameAppRule
    {
        PREFIX,
        SUFFIX
    }

    public enum task
    {
        ZERO,
        MEASURE,
        COMPEN
    }

    public enum hotKeyMessage
    {
        OPENFILE,
        SAVEFILE,
        OPENFOLDER,        
        MERGETOOL,
        OPENSCRIPT,
        GENFILE,
        OPTIONS,
        HELP,
        ABOUT,
        QUIT,
        NONE
    }
    static class UtilityParameters
    {
        public const int MAX_PATH_WIDTH = 280;
        public const double MAX_PATH_WIDTH_RATIO = 1.05;
        public static String[] manuExtList = new String[2] { ".rtl", ".pos"};
        public static String[] targetStringList = new String[2] { "Run Target Data:", "Position   	Bidirectional Avg Error" };
        public const String defaultPrefix = "ErrorCompData";
        public const String invalidFileName = "\\/*:?\"<>|";
        public const String version = "v1.0.0.0";
        public const String hotKeyString = "OSFMJGPHBQ";
        public static String[] scriptName = new String[3] { "回原点脚本", "干涉仪测量脚本", "干涉仪补偿脚本" };
    }

    static class UtilityFunctions
    {
        public static void HotKeyMessage(char keyChar, out hotKeyMessage message)
        {
            message = hotKeyMessage.NONE;
            int index = -1;
            index = UtilityParameters.hotKeyString.IndexOf(keyChar);

            if (-1 != index)
            {
                message = (hotKeyMessage)index;
            }
        }

        public static bool CheckVariableName(Control control, String input,
            bool emptyStringWarning = false, bool changeColor = false)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
            if (provider.IsValidIdentifier(input))
            {
                if (changeColor)
                {
                    control.BackColor = System.Drawing.SystemColors.Window;
                }                
                return true;
            }
            else
            {                
                if (String.Empty == input) 
                {
                    if (emptyStringWarning)
                    {
                        control.BackColor = System.Drawing.Color.Red;
                        BalloonTip ballon = new BalloonTip("不能为空", control);
                    } 
                    else
                    {
                        if (changeColor)
                        {
                            control.BackColor = System.Drawing.SystemColors.Window;
                        }
                        return true;
                    }
                }
                else
                {
                    control.BackColor = System.Drawing.Color.Red;
                    BalloonTip ballon = new BalloonTip("变量名含有非法字符", control);
                }                
                return false;
            }
        }

        public static bool CheckVariableName(String input)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
            if (provider.IsValidIdentifier(input))
            {               
                return true;
            }
            else
            {               
                return false;
            }
        }

        public static void SetReg(String keyValue)
        {
            const String keyName = "HKEY_LOCAL_MACHINE\\SOFTWARE\\LinearCalc";
            const String valueName = "Path";
            try
            {
                Registry.SetValue(keyName, valueName, keyValue);
            }
            catch (Exception ex)
            {
                return;
            }            
        }

        public static void SetReg(String[] keyValue)
        {
            const String keyName = "HKEY_LOCAL_MACHINE\\SOFTWARE\\LinearCalc";
            const String valueName = "RecentFolder";
            try
            {
                Registry.SetValue(keyName, valueName, keyValue);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public static void GetReg(out String keyValue)
        {
            const String keyName = "HKEY_LOCAL_MACHINE\\SOFTWARE\\LinearCalc";
            const String valueName = "Path";
            keyValue = "";
            try
            {
                keyValue = Registry.GetValue(keyName, valueName, "") as String;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public static void GetReg(out String[] keyValue)
        {
            const String keyName = "HKEY_LOCAL_MACHINE\\SOFTWARE\\LinearCalc";
            const String valueName = "RecentFolder";
            keyValue = null;
            try
            {
                keyValue = Registry.GetValue(keyName, valueName, null ) as String[];
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public static void ChangeVarNameToValid(Control control, int rule,
            String inputString = "", bool enablePrefix = false)
        {            
            String tempEmptyVarName = inputString;
            String tempEmptyVarNameF = tempEmptyVarName;
            char replaceChar = ' ';

            foreach (char singleChar in control.Text)
            {
                replaceChar = singleChar;
                tempEmptyVarName += replaceChar;
                if (!UtilityFunctions.CheckVariableName(tempEmptyVarName))
                {
                    control.BackColor = System.Drawing.Color.Yellow;
                    switch (rule)
                    {
                        case 0:
                            if (enablePrefix)
                            {
                                control.Text = tempEmptyVarNameF.Remove(0, inputString.Length);
                            }
                            return;
                        case 1:
                            replaceChar = '_';
                            break;
                        default:
                            break;
                    }
                }
                tempEmptyVarNameF += replaceChar;
                tempEmptyVarName = tempEmptyVarNameF;
                control.Text = tempEmptyVarNameF;
                if (enablePrefix)
                {
                    control.Text = control.Text.Remove(0, inputString.Length);
                }
                
            }
        }

        public static void ChangeVarNameToValid(ref String text, int rule, 
            String inputString = "", bool enablePrefix = false)
        {
            String tempEmptyVarName = inputString;
            String tempEmptyVarNameF = tempEmptyVarName;
            char replaceChar = ' ';

            foreach (char singleChar in text)
            {
                replaceChar = singleChar;
                tempEmptyVarName += replaceChar;
                if (!UtilityFunctions.CheckVariableName(tempEmptyVarName))
                {                    
                    switch (rule)
                    {
                        case 0:
                            if (enablePrefix)
                            {
                                text = tempEmptyVarNameF.Remove(0, inputString.Length);
                            }
                            return;
                        case 1:
                            replaceChar = '_';
                            break;
                        default:
                            break;
                    }
                }
                tempEmptyVarNameF += replaceChar;
                tempEmptyVarName = tempEmptyVarNameF;
                text = tempEmptyVarNameF;
                if (enablePrefix)
                {
                    text = text.Remove(0, inputString.Length);
                }

            }
        }
    }
}
