using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BitOperatorTest
{
    public partial class frmBitOperation : Form
    {
        public frmBitOperation()
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 왼쪽 시프트 연산자(<<)
        /// 첫째 피연산자를 둘째 피연산자에서 지정한 비트 수만큼 
        /// 비트 단위로 왼쪽으로 이동 
        /// </summary>
        private void btnLshift_Click(object sender, EventArgs e)
        {
            Int16 val1 = 0;
            Int16 val2 = 0;
            Int16 rsltVal = 0;
            String sBin1 = String.Empty;
            String sBin2 = String.Empty;
            String sBinRslt = String.Empty;

            StringBuilder rslt = new StringBuilder();

            // 피연산자1 확인
            if (CheckValue(txtHex1.Text, out val1) == false)
                return;

            // 피연산자2 확인
            if (CheckValue(txtHex2.Text, out val2) == false)
                return;

            txtResult.Clear();

            // Decimal -> Binary String
            sBin1 = $"{ConvertDecimaltoBinaryString(val1)}";
            // String 4자리마다 공백추가
            sBin1 = $"2진수 = {InsertSpacetoString(sBin1)}";

            // Decimal -> Binary String
            sBin2 = $"{ConvertDecimaltoBinaryString(val2)}";
            // String 4자리마다 공백추가
            sBin2 = $"2진수 = {InsertSpacetoString(sBin2)}";

            // <<
            rsltVal = (Int16)(val1 << val2);

            // Decimal -> Binary String
            sBinRslt = $"{ConvertDecimaltoBinaryString(rsltVal)}";
            // String 4자리마다 공백추가
            sBinRslt = $"2진수 = {InsertSpacetoString(sBinRslt)}";

            // Logging
            MakeResultLog(val1, sBin1, val2, sBin2, rsltVal, sBinRslt, "<<", ref rslt);
            
            txtResult.Text += rslt.ToString();
        }

        /// <summary> 
        /// 오른쪽 시프트 연산자(<<)
        /// 첫째 피연산자를 둘째 피연산자에서 지정한 비트 수만큼 
        /// 비트 단위로 오른쪽으로 이동 
        /// </summary>
        private void btnRshift_Click(object sender, EventArgs e)
        {
            Int16 val1 = 0;
            Int16 val2 = 0;
            Int16 rsltVal = 0;
            String sBin1 = String.Empty;
            String sBin2 = String.Empty;
            String sBinRslt = String.Empty;

            StringBuilder rslt = new StringBuilder();

            // 피연산자1 확인
            if (CheckValue(txtHex1.Text, out val1) == false)
                return;

            // 피연산자2 확인
            if (CheckValue(txtHex2.Text, out val2) == false)
                return;

            txtResult.Clear();

            // Decimal -> Binary String
            sBin1 = $"{ConvertDecimaltoBinaryString(val1)}";
            // String 4자리마다 공백추가
            sBin1 = $"2진수 = {InsertSpacetoString(sBin1)}";

            // Decimal -> Binary String
            sBin2 = $"{ConvertDecimaltoBinaryString(val2)}";
            // String 4자리마다 공백추가
            sBin2 = $"2진수 = {InsertSpacetoString(sBin2)}";

            // >>
            rsltVal = (Int16)(val1 >> val2);

            // Decimal -> Binary String
            sBinRslt = $"{ConvertDecimaltoBinaryString(rsltVal)}";
            // String 4자리마다 공백추가
            sBinRslt = $"2진수 = {InsertSpacetoString(sBinRslt)}";

            // Logging
            MakeResultLog(val1, sBin1, val2, sBin2, rsltVal, sBinRslt, ">>", ref rslt);

            txtResult.Text += rslt.ToString();
        }

        /// <summary> 
        /// Logical OR
        ///  논리 합
        /// </summary>
        private void btnOR_Click(object sender, EventArgs e)
        {
            Int16 val1 = 0;
            Int16 val2 = 0;
            Int16 rsltVal = 0;
            String sBin1 = String.Empty;
            String sBin2 = String.Empty;
            String sBinRslt = String.Empty;

            StringBuilder rslt = new StringBuilder();

            // 피연산자1 확인
            if (CheckValue(txtHex1.Text, out val1) == false)
                return;

            // 피연산자2 확인
            if (CheckValue(txtHex2.Text, out val2) == false)
                return;

            txtResult.Clear();

            // Decimal -> Binary String
            sBin1 = $"{ConvertDecimaltoBinaryString(val1)}";
            // String 4자리마다 공백추가
            sBin1 = $"2진수 = {InsertSpacetoString(sBin1)}";

            // Decimal -> Binary String
            sBin2 = $"{ConvertDecimaltoBinaryString(val2)}";
            // String 4자리마다 공백추가
            sBin2 = $"2진수 = {InsertSpacetoString(sBin2)}";

            // |
            rsltVal = (Int16)(val1 | val2);

            // Decimal -> Binary String
            sBinRslt = $"{ConvertDecimaltoBinaryString(rsltVal)}";
            // String 4자리마다 공백추가
            sBinRslt = $"2진수 = {InsertSpacetoString(sBinRslt)}";

            // Logging
            MakeResultLog(val1, sBin1, val2, sBin2, rsltVal, sBinRslt, "|", ref rslt);

            txtResult.Text += rslt.ToString();
        }

        /// <summary> 
        /// Logical AND
        ///  논리 곱
        /// </summary>
        private void btnAND_Click(object sender, EventArgs e)
        {
            Int16 val1 = 0;
            Int16 val2 = 0;
            Int16 rsltVal = 0;
            String sBin1 = String.Empty;
            String sBin2 = String.Empty;
            String sBinRslt = String.Empty;

            StringBuilder rslt = new StringBuilder();

            // 피연산자1 확인
            if (CheckValue(txtHex1.Text, out val1) == false)
                return;

            // 피연산자2 확인
            if (CheckValue(txtHex2.Text, out val2) == false)
                return;

            txtResult.Clear();

            // Decimal -> Binary String
            sBin1 = $"{ConvertDecimaltoBinaryString(val1)}";
            // String 4자리마다 공백추가
            sBin1 = $"2진수 = {InsertSpacetoString(sBin1)}";

            // Decimal -> Binary String
            sBin2 = $"{ConvertDecimaltoBinaryString(val2)}";
            // String 4자리마다 공백추가
            sBin2 = $"2진수 = {InsertSpacetoString(sBin2)}";

            // &
            rsltVal = (Int16)(val1 & val2);

            // Decimal -> Binary String
            sBinRslt = $"{ConvertDecimaltoBinaryString(rsltVal)}";
            // String 4자리마다 공백추가
            sBinRslt = $"2진수 = {InsertSpacetoString(sBinRslt)}";

            // Logging
            MakeResultLog(val1, sBin1, val2, sBin2, rsltVal, sBinRslt, "&", ref rslt);

            txtResult.Text += rslt.ToString();
        }

        /// <summary> 
        /// Logical exclusive-OR 
        /// (배타적 논리합)
        /// 기존 값과 변화된 값을 찾을 때 유용함
        /// </summary>
        private void btnXOR_Click(object sender, EventArgs e)
        {
            Int16 val1 = 0;
            Int16 val2 = 0;
            Int16 rsltVal = 0;
            String sBin1 = String.Empty;
            String sBin2 = String.Empty;
            String sBinRslt = String.Empty;

            StringBuilder rslt = new StringBuilder();

            // 피연산자1 확인
            if (CheckValue(txtHex1.Text, out val1) == false)
                return;

            // 피연산자2 확인
            if (CheckValue(txtHex2.Text, out val2) == false)
                return;

            txtResult.Clear();

            // Decimal -> Binary String
            sBin1 = $"{ConvertDecimaltoBinaryString(val1)}";
            // String 4자리마다 공백추가
            sBin1 = $"2진수 = {InsertSpacetoString(sBin1)}";

            // Decimal -> Binary String
            sBin2 = $"{ConvertDecimaltoBinaryString(val2)}";
            // String 4자리마다 공백추가
            sBin2 = $"2진수 = {InsertSpacetoString(sBin2)}";

            // ^
            rsltVal = (Int16)(val1 ^ val2);

            // Decimal -> Binary String
            sBinRslt = $"{ConvertDecimaltoBinaryString(rsltVal)}";
            // String 4자리마다 공백추가
            sBinRslt = $"2진수 = {InsertSpacetoString(sBinRslt)}";

            // Logging
            MakeResultLog(val1, sBin1, val2, sBin2, rsltVal, sBinRslt, "^", ref rslt);

            txtResult.Text += rslt.ToString();

        }

        /// <summary> Clear </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
        }

        /// <summary> txtHex1_KeyDown </summary>
        private void txtHex1_KeyDown(object sender, KeyEventArgs e)
        {
            Int16 val = 0;
            String sBin = String.Empty;

            if (e.KeyCode != Keys.Enter)
                return;

            try
            {
                // hex -> dec
                if (txtHex1.Text.StartsWith("0X") == true ||
                    txtHex1.Text.StartsWith("0x") == true)
                    val = Convert.ToInt16(txtHex1.Text.Substring(2, txtHex1.Text.Length - 2), 16);
                else
                if (Int16.TryParse(txtHex1.Text, NumberStyles.HexNumber, new CultureInfo("en-US"), out val) == false)
                    //val = Convert.ToInt16(txtHex1.Text, 16);
                    return;

                sBin = Convert.ToString(val, 2).PadLeft(16, '0');

                //// 정수값 표현에 사용 (4자리마다 Space)
                //Int16[] groupSizes = new Int16[] { 4 };
                //NumberFormatInfo formatInfo = new NumberFormatInfo() { NumberGroupSeparator = " ", NumberGroupSizes = groupSizes };

                // hex -> dec
                txtDec1.Text = val.ToString();

                // hex -> bin
                txtBin1.Text = Regex.Replace(sBin, ".{4}", "$0 ");  // 4자리 띄워쓰기
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary> txtDec1_KeyDown </summary>
        private void txtDec1_KeyDown(object sender, KeyEventArgs e)
        {
            Int16 val = 0;
            String sBin = String.Empty;

            if (e.KeyCode != Keys.Enter)
                return;

            try
            {
                if (String.IsNullOrWhiteSpace(txtDec1.Text) == true ||
                    Int16.TryParse(txtDec1.Text, out val) == false)
                    return;

                // dec -> hex
                txtHex1.Text = $"0x{ Convert.ToString(val, 16).PadLeft(4, '0')}";

                // dec -> bin
                // Binary String
                sBin = Convert.ToString(val, 2).PadLeft(16, '0');
                txtBin1.Text = Regex.Replace(sBin, ".{4}", "$0 ");  // 4자리 띄워쓰기
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary> txtHex2_KeyDown </summary>
        private void txtHex2_KeyDown(object sender, KeyEventArgs e)
        {
            Int16 val = 0;
            String sBin = String.Empty;

            if (e.KeyCode != Keys.Enter)
                return;

            try
            {
                // hex -> dec
                if (txtHex2.Text.StartsWith("0X") == true ||
                   txtHex2.Text.StartsWith("0x") == true)
                    val = Convert.ToInt16(txtHex2.Text.Substring(2, txtHex2.Text.Length - 2), 16);
                else
               if (Int16.TryParse(txtHex2.Text, NumberStyles.HexNumber, new CultureInfo("en-US"), out val) == false)
                    //val = Convert.ToInt16(txtHex2.Text, 16);
                    return;


                sBin = Convert.ToString(val, 2).PadLeft(16, '0');

                // 정수값 표현에 사용 (4자리마다 Space)
                Int32[] groupSizes = new Int32[] { 4 };
                NumberFormatInfo formatInfo = new NumberFormatInfo() { NumberGroupSeparator = " ", NumberGroupSizes = groupSizes };

                // hex -> dec
                txtDec2.Text = val.ToString();

                // hex -> bin
                txtBin2.Text = Regex.Replace(sBin, ".{4}", "$0 ");  // 4자리 띄워쓰기
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary> txtDec2_KeyDown </summary>
        private void txtDec2_KeyDown(object sender, KeyEventArgs e)
        {
            Int16 val = 0;
            String sBin = String.Empty;

            if (e.KeyCode != Keys.Enter)
                return;

            try
            {
                if (String.IsNullOrWhiteSpace(txtDec2.Text) == true ||
                    Int16.TryParse(txtDec2.Text, out val) == false)
                    return;

                // dec -> hex
                txtHex2.Text = $"0x{ Convert.ToString(val, 16).PadLeft(4, '0')}";

                // dec -> bin
                // Binary String
                sBin = Convert.ToString(val, 2).PadLeft(16, '0');
                txtBin2.Text = Regex.Replace(sBin, ".{4}", "$0 ");  // 4자리 띄워쓰기
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary> txtBin1_KeyDown </summary>
        private void txtBin1_KeyDown(object sender, KeyEventArgs e)
        {
            Int16 val = 0;
            String sBin = String.Empty;

            if (e.KeyCode != Keys.Enter)
                return;

            try
            {
                if (String.IsNullOrWhiteSpace(txtBin1.Text) == true)
                    return;

                sBin = txtBin1.Text.Replace(" ", "");

                // Conert BinaryString to Int16
                val = Convert.ToInt16(sBin, 2);

                txtDec1.Text = val.ToString();

                // dec -> hex
                txtHex1.Text = $"0x{ Convert.ToString(val, 16).PadLeft(4, '0')}";

                // dec -> bin
                // Binary String
                sBin = Convert.ToString(val, 2).PadLeft(16, '0');
                txtBin1.Text = Regex.Replace(sBin, ".{4}", "$0 ");  // 4자리 띄워쓰기
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary> txtBin2_KeyDown </summary>
        private void txtBin2_KeyDown(object sender, KeyEventArgs e)
        {
            Int16 val = 0;
            String sBin = String.Empty;

            if (e.KeyCode != Keys.Enter)
                return;

            try
            {
                if (String.IsNullOrWhiteSpace(txtBin2.Text) == true)
                    return;

                sBin = txtBin2.Text.Replace(" ", "");

                // Conert BinaryString to Int16
                val = Convert.ToInt16(sBin, 2);

                txtDec2.Text = val.ToString();

                // dec -> hex
                txtHex2.Text = $"0x{ Convert.ToString(val, 16).PadLeft(4, '0')}";

                // dec -> bin
                // Binary String
                sBin = Convert.ToString(val, 2).PadLeft(16, '0');
                txtBin2.Text = Regex.Replace(sBin, ".{4}", "$0 ");  // 4자리 띄워쓰기
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary> 0, 1 만 입력 </summary>
        private void txtBin1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링 (char.IsDigit(e.KeyChar))
            if ((e.KeyChar != Convert.ToChar(Keys.Back) &&
                e.KeyChar != Convert.ToChar(Keys.D0) &&
                e.KeyChar != Convert.ToChar(Keys.D1) &&
                e.KeyChar != Convert.ToChar(Keys.Space) &&
                e.KeyChar != Convert.ToChar(Keys.Enter)))
            {
                e.Handled = true;
            }

        }

        /// <summary> 0, 1 만 입력 </summary>
        private void txtBin2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링 (char.IsDigit(e.KeyChar))
            if ((e.KeyChar != Convert.ToChar(Keys.Back) &&
                e.KeyChar != Convert.ToChar(Keys.D0) &&
                e.KeyChar != Convert.ToChar(Keys.D1) &&
                e.KeyChar != Convert.ToChar(Keys.Space) &&
                e.KeyChar != Convert.ToChar(Keys.Enter)))
            {
                e.Handled = true;
            }
        }

        /// <summary> Check Value </summary>
        private bool CheckValue(string text, out Int16 val1)
        {
            Boolean rtnVal = false;
            val1 = 0;

            if (text.StartsWith("0X") == true ||
                text.StartsWith("0x") == true)
            {
                val1 = Convert.ToInt16(text.Substring(2, text.Length - 2), 16);
                rtnVal = true;
            }
            else
            {
                rtnVal = Int16.TryParse(text, NumberStyles.HexNumber, 
                                new CultureInfo("en-US"), out val1);
            }

            return rtnVal;
        }

        /// <summary> Convert Decimal to BinaryString </summary>
        private String ConvertDecimaltoBinaryString(short val1)
        {
            return Convert.ToString(val1, 2).PadLeft(16, '0');
        }

        /// <summary> Insert Space to String </summary>
        private string InsertSpacetoString(string sBin1)
        {
            // 4자리 마다 공백 추가
            return Regex.Replace(sBin1, ".{4}", "$0 ");
        }

        /// <summary> Convert Decimal to HexadecimalString[value.ToString("X4")] </summary>
        private object ConvertDecimaltoHexString(short val1)
        {
            return Convert.ToString(val1, 16).PadLeft(4, '0');
        }

        /// <summary> Logging </summary>
        private void MakeResultLog(Int16 val1, String sBin1, Int16 val2,
                                String sBin2, Int16 rsltVal, String sBinRslt, 
                                String oper, ref StringBuilder rslt)
        {
            rslt.Append($"피연산자1 = 0x{val1:X4}");    // Decimal -> Hexadecimal String
            rslt.Append($", {sBin1}");
            rslt.Append($", 10진수 = {val1}");
            rslt.AppendLine();

            rslt.Append($"피연산자2 = 0x{val2:X4}");
            rslt.Append($", {sBin2}");
            rslt.Append($", 10진수 = {val2}");
            rslt.AppendLine();

            rslt.AppendLine($" [Calculate] 0x{val1:X4} {oper} 0x{val2:X4} =");
            rslt.Append($"결 과  값 = 0x{rsltVal:X4}");
            rslt.Append($", {sBinRslt}");
            rslt.Append($", 10진수 = {rsltVal}");
            rslt.AppendLine();
        }
        
        private const Int16 PLC_MXR_BUSY = 0x0001;


        /// <summary>
        /// Blending Mixing Control Word
        /// </summary>
        public enum BlendMCW
        {
            /// <summary>
            /// Unknown
            /// </summary>
            Unknown = 0x0000,

            // 0X0001 : 예비

            /// <summary> 
            /// FS/F1 Discharge request
            /// </summary> 
            MXR1_DCHRQ = 0x0002,

            // 0X0004 : 예비
            // 0X0008 : 예비

            // 0X0010 : 예비
            // 0X0020 : 예비
            // 0X0040 : 예비

            /// <summary> 
            /// FS/F1 Mixing request
            /// </summary> 
            MXR1_MIXRQ = 0x0080,

            // 0X0100 : 예비

            /// <summary> 
            /// F2 Discharge request
            /// </summary> 
            MXR2_DCHRQ = 0x0200,

            // 0X0400 : 예비
            // 0X0800 : 예비

            // 0X1000 : 예비
            // 0X2000 : 예비
            // 0X4000 : 예비

            /// <summary> 
            /// F2 Mixing request
            /// </summary> 
            MXR2_MIXRQ = 0x8000,

        }

        public enum BlendLineNum
        {
            BLD_FS = 1,
            BLD_F2 = 2,
        }

        /// <summary>
        /// Blending Mixing Status Word
        /// </summary>
        [Flags]
        public enum BlendMSW
        {
            /// <summary>
            /// Unknown
            /// </summary>
            Unknown = 0x0000,

            /// <summary> 
            /// FS/F1 Mixer 정상(1)/비정상(0)
            /// </summary> 
            MXR1_OK = 0x0001,
            /// <summary> 
            /// FS/F1 Mixer ALARM: MIXER door not opened
            /// </summary> 
            MAL1_NOPEN = 0X0002,
            /// <summary> 
            /// FS/F1 Mixer ALARM: MIXER door not closed
            /// </summary> 
            MAL1_NCLOSE = 0X0004,
            /// <summary> 
            /// FS/F1 Mixer Dischare complete
            /// </summary> 
            MXR1_DEND = 0x0008,

            /// <summary> 
            /// FS/F1 Mixer Surge Hopper Low Level
            /// </summary> 
            MXR1_SHLL = 0x0010,
            /// <summary> 
            /// FS/F1 Mixer ALARM: Mixer fault(Hold)
            /// </summary> 
            MAL1_FLT = 0x0020,
            /// <summary> 
            /// FS/F1 Mixer Mixing Completed
            /// </summary> 
            MXR1_MEND = 0x0040,
            /// <summary> 
            /// FS/F1 Mixer Mixing중/Discharge중
            /// </summary> 
            MXR1_MXDC = 0x0080,

            /// <summary> 
            /// F2 Mixer 정상(1)/비정상(0)
            /// </summary> 
            MXR2_OK = 0x0100,
            /// <summary> 
            /// F2 Mixer ALARM: MIXER door not opened
            /// </summary> 
            MAL2_NOPEN = 0X0200,
            /// <summary> 
            /// F2 Mixer ALARM: MIXER door not closed
            /// </summary> 
            MAL2_NCLOSE = 0X0400,
            /// <summary> 
            /// F2 Mixer Dischare complete
            /// </summary> 
            MXR2_DEND = 0x0800,

            /// <summary> 
            /// F2 Mixer Surge Hopper Low Level
            /// </summary> 
            MXR2_SHLL = 0x1000,
            /// <summary> 
            /// F2 Mixer ALARM: Mixer fault(Hold)
            /// </summary> 
            MAL2_FLT = 0x2000,
            /// <summary> 
            /// F2 Mixer Mixing Completed
            /// </summary> 
            MXR2_MEND = 0x4000,
            /// <summary> 
            /// F2 Mixer Mixing중/Discharge중
            /// </summary> 
            MXR2_MXDC = 0x8000,
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            String s = BlendLineNum.BLD_F2.ToString();
            Int16 curBlendMSW = 512;
            BlendLineNum lineNum;

            UInt16 _PrevMixAlarm = 8;
            UInt16 _mask = 0;
            
            _PrevMixAlarm <<= 8;

            _PrevMixAlarm &= (UInt16)(_PrevMixAlarm ^(UInt16)BlendMSW.MAL1_FLT);

            _mask = _PrevMixAlarm;
            _mask ^= (UInt16)BlendMSW.MAL1_FLT;
            _PrevMixAlarm &= _mask;


            //s = curBlendMSW.ToString("X4");
            s = DateTime.Now.ToString("yyyyMMddHHmmss");

            s = String.Format("{0:D4}_{1:D4}_{2:D4}_{3:D14}", 1, 2, 30, s);
            if (Enum.IsDefined(typeof(BlendLineNum), s) == false)
                curBlendMSW = 10;
            else
                curBlendMSW = 110;
            
            lineNum = (BlendLineNum)Enum.Parse(typeof(BlendLineNum), s);

            if (Enum.IsDefined(typeof(BlendLineNum), Enum.Parse(typeof(BlendLineNum),s)) == false)
                curBlendMSW = 10;

            if (Enum.TryParse<BlendLineNum>(s, out lineNum) == false)
                curBlendMSW = 11;


            Int32 temp = (Int32)BlendMCW.MXR2_MIXRQ | PLC_MXR_BUSY;
            curBlendMSW = (Int16)temp;

            BlendMCW test = BlendMCW.MXR2_MIXRQ;
            test = BlendMCW.MXR2_MIXRQ | BlendMCW.MXR2_DCHRQ;
            test = BlendMCW.MXR2_MIXRQ | ~BlendMCW.MXR2_DCHRQ| BlendMCW.MXR1_MIXRQ;
            //test = BlendMCW.MXR2_MIXRQ | BlendMCW.MXR2_DCHRQ| BlendMCW.MXR1_MIXRQ | (BlendMCW)PLC_MXR_BUSY;

            Int16 itest = (Int16)test;

            String test1 = $"{test}";
            {
                txtResult.Text = "";

            }
        }
    }
}
