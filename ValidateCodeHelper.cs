using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Forms.Common.SmsHelper
{
    public class ValidateCodeHelper
    {
        /// <summary>
        /// 验证码的最大长度
        /// </summary>
        public int MaxLength
        {
            get { return 6; }
        }
        /// <summary>
        /// 验证码的最小长度
        /// </summary>
        public int MinLength
        {
            get { return 6; }
        }


        public string CreateValidateCode(int length)
        {
            int[] randMembrs = new int[length];
            int[] validateNums = new int[length];
            string validateNumberStr = "";
            //生成起始序列号
            int seekSeek = unchecked((int)DateTime.Now.Ticks);
            Random seekRand = new Random(seekSeek);
            int beginSeek = (int)seekRand.Next(0, Int32.MaxValue - length * 10000);
            int[] seeks = new int[length];
            for (int i = 0; i < length; i++)
            {
                beginSeek += 10000;
                seeks[i] = beginSeek;
            }
            //生成随机数
            for (int i = 0; i < length; i++)
            {
                Random rand = new Random(seeks[i]);
                int pownum = 1 * (int)Math.Pow(10,length);
                randMembrs[i] = rand.Next(pownum,Int32.MaxValue);
            }
            //抽取随机数字
            for (int i = 0; i < length; i++)
            {
                string numStr = randMembrs[i].ToString();
                int numLength = numStr.Length;
                Random rand = new Random();
                int numPosition = rand.Next(0,numLength-1);
                validateNums[i] = Int32.Parse(numStr.Substring(numPosition,1));
            }
            //生成验证码
            for (int i = 0; i < length; i++)
            {
                validateNumberStr += validateNums[i].ToString();
            }
            return validateNumberStr;

        }
    }
}
