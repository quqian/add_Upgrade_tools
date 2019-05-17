using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Threading;

//using System.IO.Ports;
//using System.Runtime.InteropServices;
//using UniLua;

namespace AutoTestTool
{
    public partial class dfu_Form : Form
    {
        public dfu_Form()
        {
            InitializeComponent();
        }
        bool IsFileOpened = false;
        long FileLength = 0;
        long toal_FileLength = 0;
        long send_dfu_Length = 0;
        int UpGradeValue = 0;
        byte[] OriginalFileDatas;
        string OriginalFilePath = string.Empty, UpdateFilePath = string.Empty;
        Int16 FwVersion = 0;
        UInt32 u32_check_sum = 0;
        string str_project_name = "";
        System.Text.StringBuilder StrOforiginalFile = new System.Text.StringBuilder(), strOfNewFile = new System.Text.StringBuilder();
        Thread dfu_Thread;
        static byte dfu_serial_number = 0;
        public static List<byte> arraybuffer = new List<byte> { };

        public ushort[] CRC16Table = {
           0x0, 0x1021, 0x2042, 0x3063, 0x4084, 0x50A5, 0x60C6, 0x70E7,
           0x8108, 0x9129, 0xA14A, 0xB16B, 0xC18C, 0xD1AD, 0xE1CE, 0xF1EF,
           0x1231, 0x210, 0x3273, 0x2252, 0x52B5, 0x4294, 0x72F7, 0x62D6,
           0x9339, 0x8318, 0xB37B, 0xA35A, 0xD3BD, 0xC39C, 0xF3FF, 0xE3DE,
           0x2462, 0x3443, 0x420, 0x1401, 0x64E6, 0x74C7, 0x44A4, 0x5485,
           0xA56A, 0xB54B, 0x8528, 0x9509, 0xE5EE, 0xF5CF, 0xC5AC, 0xD58D,
           0x3653, 0x2672, 0x1611, 0x630, 0x76D7, 0x66F6, 0x5695, 0x46B4,
           0xB75B, 0xA77A, 0x9719, 0x8738, 0xF7DF, 0xE7FE, 0xD79D, 0xC7BC,
           0x48C4, 0x58E5, 0x6886, 0x78A7, 0x840, 0x1861, 0x2802, 0x3823,
           0xC9CC, 0xD9ED, 0xE98E, 0xF9AF, 0x8948, 0x9969, 0xA90A, 0xB92B,
           0x5AF5, 0x4AD4, 0x7AB7, 0x6A96, 0x1A71, 0xA50, 0x3A33, 0x2A12,
           0xDBFD, 0xCBDC, 0xFBBF, 0xEB9E, 0x9B79, 0x8B58, 0xBB3B, 0xAB1A,
           0x6CA6, 0x7C87, 0x4CE4, 0x5CC5, 0x2C22, 0x3C03, 0xC60, 0x1C41,
           0xEDAE, 0xFD8F, 0xCDEC, 0xDDCD, 0xAD2A, 0xBD0B, 0x8D68, 0x9D49,
           0x7E97, 0x6EB6, 0x5ED5, 0x4EF4, 0x3E13, 0x2E32, 0x1E51, 0xE70,
           0xFF9F, 0xEFBE, 0xDFDD, 0xCFFC, 0xBF1B, 0xAF3A, 0x9F59, 0x8F78,
           0x9188, 0x81A9, 0xB1CA, 0xA1EB, 0xD10C, 0xC12D, 0xF14E, 0xE16F,
           0x1080, 0xA1, 0x30C2, 0x20E3, 0x5004, 0x4025, 0x7046, 0x6067,
           0x83B9, 0x9398, 0xA3FB, 0xB3DA, 0xC33D, 0xD31C, 0xE37F, 0xF35E,
           0x2B1, 0x1290, 0x22F3, 0x32D2, 0x4235, 0x5214, 0x6277, 0x7256,
           0xB5EA, 0xA5CB, 0x95A8, 0x8589, 0xF56E, 0xE54F, 0xD52C, 0xC50D,
           0x34E2, 0x24C3, 0x14A0, 0x481, 0x7466, 0x6447, 0x5424, 0x4405,
           0xA7DB, 0xB7FA, 0x8799, 0x97B8, 0xE75F, 0xF77E, 0xC71D, 0xD73C,
           0x26D3, 0x36F2, 0x691, 0x16B0, 0x6657, 0x7676, 0x4615, 0x5634,
           0xD94C, 0xC96D, 0xF90E, 0xE92F, 0x99C8, 0x89E9, 0xB98A, 0xA9AB,
           0x5844, 0x4865, 0x7806, 0x6827, 0x18C0, 0x8E1, 0x3882, 0x28A3,
           0xCB7D, 0xDB5C, 0xEB3F, 0xFB1E, 0x8BF9, 0x9BD8, 0xABBB, 0xBB9A,
           0x4A75, 0x5A54, 0x6A37, 0x7A16, 0xAF1, 0x1AD0, 0x2AB3, 0x3A92,
           0xFD2E, 0xED0F, 0xDD6C, 0xCD4D, 0xBDAA, 0xAD8B, 0x9DE8, 0x8DC9,
           0x7C26, 0x6C07, 0x5C64, 0x4C45, 0x3CA2, 0x2C83, 0x1CE0, 0xCC1,
           0xEF1F, 0xFF3E, 0xCF5D, 0xDF7C, 0xAF9B, 0xBFBA, 0x8FD9, 0x9FF8,
           0x6E17, 0x7E36, 0x4E55, 0x5E74, 0x2E93, 0x3EB2, 0xED1, 0x1EF0
        };

        enum DFU_Command
        {
            CMD_FW_UPDATE_REQ = 0x0,                        //固件升级请求
            CMD_FW_UPDATE_SEND = 0x1,                     //固件下发
            TestMode = 0x99
        };

        public static UInt32 check_sum(byte[] buffer, long length, long start_index)
        {
            UInt32 sum = 0;

            for (long i = start_index; i < length + start_index; i++)
            {
                sum += buffer[i];
            }

            return sum;
        }

        public static string fillString(string srcstr, int destLen, char fillChar, int index)
        {

            string str;
            str = srcstr;
            if (srcstr.Length < destLen)
            {
                for (int i = 0; i < destLen - srcstr.Length; i++)
                {
                    str = str.Insert(index, fillChar.ToString());
                }
            }
            return str;
        }

        public static byte[] stringToBCD(string text)
        {
            if (text.Length % 2 != 0)
            {
                text = text.Insert(0, "0");
            }
            byte[] array = new byte[text.Length / 2];
            string str = "";
            int j = 0;
            try
            {
                for (int i = 0; i < text.Length; i += 2)
                {
                    str = text[i].ToString() + text[i + 1].ToString();

                    array[j] = byte.Parse(str, System.Globalization.NumberStyles.HexNumber);

                    j++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return array;

        }

        private void skinButton_Login_Click(object sender, EventArgs e)
        {
            

            
        }

        public int CRC16(Byte[] dat, long start, long count)
        {
            int crc = 0;
            Byte crctemp;
            int i = 0;
            while (count > 0)
            {
                count -= 1;
                crctemp = Convert.ToByte(crc >> 8);
                crc = (crc << 8) & 0xFFFF;
                crc = (CRC16Table[crctemp ^ dat[i + start]] ^ crc) & 0xFFFF;
                i += 1;
            }
            return crc;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "异常提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void textBox_LoginCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                skinButton_Login_Click(sender, e);
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            //radioButton2.Checked = false;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            //radioButton1.Checked = false;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox_software_version_TextChanged(object sender, EventArgs e)
        {

        }
        //事先已经知道文件的长度
        //打开文件并将其放到数组中来
        private Byte[] OpenFileAndChangeToBytes(string Path)
        {
            //--把事情搞复杂了！！直接一个函数调用就完了！！
            //打开文件
            /*FileStream OriginalFS = new FileStream(OriginalFilePath, FileMode.Open);

            //读取文件到数组
            byte[] OriginalFileDatas = new byte[FileLength];
            OriginalFS.Read(OriginalFileDatas, 0, OriginalFileDatas.Length);

            //这里需要关闭文件吗？？
            OriginalFS.Flush();
            OriginalFS.Close();*/

            return File.ReadAllBytes(Path);
        }

        //显示多个字节
        StringBuilder ShowBytes(Byte[] Buff, UInt32 StartOfBuff)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            for (UInt32 i = StartOfBuff; i < Buff.Length; i++)
            {
                if (i % 16 == 0)
                {
                    sb.Append(i.ToString("X4"));
                    sb.Append(i.ToString(" : "));
                }

                sb.Append(Buff[i].ToString("X2"));
                sb.Append(Buff[i].ToString(" "));

                if ((i + 1) % 16 == 0)
                {
                    sb.Append(Buff[i].ToString("\r\n"));
                }
            }

            return sb;

            /*string strOfNewFile = "";
            for (UInt32 i = StartOfBuff; i < Buff.Length; i++)
            {
                if (i % 16 == 0)
                {
                    strOfNewFile += i.ToString("X4");
                    strOfNewFile += " : ";
                }

                strOfNewFile += Buff[i].ToString("X2");
                strOfNewFile += " ";
                if ((i + 1) % 16 == 0)
                {
                    strOfNewFile += "\r\n";
                }
            }

            return strOfNewFile;*/
        }

        private void Button_open_file_Click(object sender, EventArgs e)
        {
            if (!dfu_serialPort.IsOpen)
            {
                MessageBox.Show("请打开串口!");
            }
            else {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    IsFileOpened = true;
                    OriginalFilePath = comboBox_PathAndFile.Text = openFileDialog1.FileName;

                    //文件大小：XXX字节 创建时间：
                    FileInfo MyFileInfo = new FileInfo(OriginalFilePath);
                    FileLength = MyFileInfo.Length;
                    toal_FileLength = FileLength;
                    toolStripStatusLabel1.Text = "文件大小：" + Convert.ToString(FileLength) + "字节；" + "创建时间：" + Convert.ToString(MyFileInfo.CreationTime);

                    //打开文件并转化为数组
                    Byte[] TempArray = new Byte[FileLength];
                    OriginalFileDatas = TempArray;

                    Array.Copy(OpenFileAndChangeToBytes(OriginalFilePath), 0, OriginalFileDatas, 0, FileLength);

                    ////显示文件内容
                    //StrOforiginalFile = ShowBytes(OriginalFileDatas, 32);
                    //txtbox_original.Text = StrOforiginalFile.ToString();
                }
            }
        }

        private void ToolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox_project_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button_open_serial_Click(object sender, EventArgs e)
        {
            try
            {
                if (!dfu_serialPort.IsOpen)
                {
                    dfu_serialPort.BaudRate = int.Parse(ComboBox_dfu_SerialBuateSelect.SelectedItem.ToString());
                    dfu_serialPort.PortName = ComboBox_dfu_SerialPortSelect.SelectedItem.ToString();
                    dfu_serialPort.Open();
                    if (dfu_serialPort.IsOpen)
                    {
                        button_open_serial.Text = "关闭串口";
                    }
                }
                else
                {
                    dfu_serialPort.Close();

                    if (!dfu_serialPort.IsOpen)
                    {
                        button_open_serial.Text = "打开串口";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //生成文件头
        private void CreateFileHead()
        {
            //int buff_length = 0;
            //byte[] byteArray = System.Text.Encoding.Default.GetBytes(textBox_project_name.Text);
            //if (byteArray.Length > 16)
            //{
            //    MessageBox.Show("工程文件名太长!");
            //}
            //else {
            //    //给数组的前面生成32个0xFF
            //    for (int i = 0; i < 32; i++)
            //    {
            //        OriginalFileDatas[i] = 0xFF;
            //    }
            //    //起始标志
            //    OriginalFileDatas[0] = (Byte)(0xaa);
            //    OriginalFileDatas[1] = (Byte)(0x55);
            //    //版本
            //    FwVersion = Convert.ToInt16(textBox_software_version.Text);
            //    OriginalFileDatas[2] = (Byte)(FwVersion & 0x00ff);
            //    OriginalFileDatas[3] = (Byte)(FwVersion >> 8);

            //    //长度
            //    OriginalFileDatas[4] = (Byte)(FileLength & 0x000000ff);
            //    OriginalFileDatas[5] = (Byte)((FileLength & 0x0000ff00) >> 8);
            //    OriginalFileDatas[6] = (Byte)((FileLength & 0x00ff0000) >> 16);
            //    OriginalFileDatas[7] = (Byte)((FileLength & 0xff000000) >> 24);
            //    //bin文件校验和
            //    u32_check_sum = check_sum(OriginalFileDatas, FileLength, 32);
            //    OriginalFileDatas[8] = (Byte)(u32_check_sum & 0x000000ff);
            //    OriginalFileDatas[9] = (Byte)((u32_check_sum & 0x0000ff00) >> 8);
            //    OriginalFileDatas[10] = (Byte)((u32_check_sum & 0x00ff0000) >> 16);
            //    OriginalFileDatas[11] = (Byte)((u32_check_sum & 0xff000000) >> 24);

            //    for (int i = 0; i < byteArray.Length; i++)
            //    {
            //        OriginalFileDatas[16 + i] = byteArray[i];
            //    }
            //    ////增加文件CRC
            //    //int fw_crc = CRC16(OriginalFileDatas, 16, FileLength);
            //    //OriginalFileDatas[6] = Convert.ToByte(fw_crc & 0x000000ff);
            //    //OriginalFileDatas[7] = Convert.ToByte((fw_crc & 0x0000ff00) >> 8);

            //    ////增加整个头前14个字节的CRC
            //    //fw_crc = CRC16(OriginalFileDatas, 0, 14);
            //    //OriginalFileDatas[14] = Convert.ToByte(fw_crc & 0x000000ff);
            //    //OriginalFileDatas[15] = Convert.ToByte((fw_crc & 0x0000ff00) >> 8);
            //}
        }
        //串口发送
        private bool SendSerialData(byte[] data)
        {
            bool ret = false;

            try
            {
                if (dfu_serialPort != null)
                {
                    dfu_serialPort.Write(data, 0, data.Length);

                    //if (X6MsgDebug)
                    //{
                    //    string send = "";
                    //    for (int j = 0; j < data.Length; j++)
                    //    {
                    //        send += data[j].ToString("X2") + " ";
                    //    }
                    //   // LOG("Send: " + send);
                    //}
                    ret = true;
                }
            }
            catch (Exception ex)
            {
               // LOG(ex.Message);
                ret = false;
            }
            return ret;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dfu_Thread != null)
            {
                if (dfu_Thread.IsAlive)
                {
                    dfu_Thread.Abort();
                    dfu_Thread = null;
                }
            }
        }

        private static byte[] MakeSendArray(byte cmd, byte[] data)
        {
            UInt16 length;
            List<byte> list = new List<byte> { };
            byte[] srtDes = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            list.Add(0xAA);
            list.Add(0x55);

            list.AddRange(srtDes);
            byte ver = 0x01;
            dfu_serial_number++;

            if (data != null)
            {
                length = (UInt16)(1 + 1 + 1 + data.Length + 1);
            }
            else
            {
                length = 2;
            }

            list.Add((byte)(length));
            list.Add((byte)(length >> 8));
            list.Add(ver);
            list.Add(dfu_serial_number);
            list.Add(cmd);
            if (data != null)
            {
                list.AddRange(data);
            }

            list.Add(ProcTestData.caculatedCRC(list.ToArray(), list.Count));

            return list.ToArray();
        }

        private void SendSetGwAddr(string addrStr)
        {
            try
            {
                //string[] addr = addrStr.Split('.');
                //byte[] data = new byte[addr.Length];

                //for (int i = 0; i < data.Length; i++)
                //{
                //    data[i] = Convert.ToByte(addr[i]);
                //}

                string str = ProcTestData.fillString(addrStr, 10, '0', 0);
                byte[] data = ProcTestData.stringToBCD(str);
                //byte[] data = Encoding.Default.GetBytes(addr);
                SendSerialData(MakeSendArray((byte)DFU_Command.CMD_FW_UPDATE_SEND, data));
            }
            catch (Exception ex)
            {

                //updateText("异常：" + ex.Message);
            }

        }

        private void Button_test_Click(object sender, EventArgs e)
        {
            SendSetGwAddr(textBox_send.Text.Trim());
        }

        private void ComboBox_dfu_SerialPortSelect_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox_dfu_SerialPortSelect_DropDown(object sender, EventArgs e)
        {
            try
            {
                ComboBox_dfu_SerialPortSelect.Items.Clear();

                foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
                {//获取多少串口
                    ComboBox_dfu_SerialPortSelect.Items.Add(s);
                }

                if (ComboBox_dfu_SerialPortSelect.Items.Count > 0)
                {
                    ComboBox_dfu_SerialPortSelect.SelectedIndex = 0;
                    ComboBox_dfu_SerialBuateSelect.SelectedIndex = 0;
                }
                else
                {
                    ComboBox_dfu_SerialPortSelect.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示");
            }
        }

        public void LOG_UPGrade(String text)
        {
            try
            {
                this.textBox_send.Invoke(
                    new MethodInvoker(delegate
                    {
                        //   this.X6textBoxConfigPrint.AppendText(text + "\r\n");
                        this.textBox_send.Text = "";
                        this.textBox_send.AppendText(text);
                    }
                 )
                );
            }
            catch (Exception ex)
            {
               // LOG(ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }

        public void receive_LOG(String text)
        {
            try
            {
                this.textBox_txt_show_recv.Invoke(
                    new MethodInvoker(delegate
                    {
                        this.textBox_txt_show_recv.AppendText(text);
                    }
                 )
                );
            }
            catch (Exception ex)
            {
                // LOG(ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }

        private void dfu_upgrade_progress()
        {
            string pStrUpgrade = "";
            UpGradeValue = (int)(send_dfu_Length * 100 / OriginalFileDatas.Length);

            //progressBar1.Value = (int)10;
        //    pStrUpgrade = UpGradeValue.ToString("D2") + "%";
        //    Label_UpGrade.Text = pStrUpgrade;
        }

        byte[] data = new byte[64];
        //  Byte[] TempArray = new Byte[FileLength];
        long i = 0;
        long k = 0;
        //升级线程
        private void dfu_StartUpGradeProcess()
        {
            send_dfu_Length = 0;
            byte[] p_buf_receive = new byte[16];

            while (true)
            {
                LOG_UPGrade("" + send_dfu_Length.ToString("X2"));
                if ((FileLength < 64) && (FileLength > 0))
                {
                    for (i = 0; i < FileLength; i++)
                    {
                        data[i] = OriginalFileDatas[send_dfu_Length++];
                        //byte[] data = Encoding.Default.GetBytes(addr);
                    }
                    for (i = FileLength; i < 64; i++)
                    {
                        data[i] = 0;
                    }
                    serial_show_recv_data(data);
                    FileLength = 0;
                    LOG_UPGrade("" + send_dfu_Length.ToString("X2"));
                    // SendSerialData(MakeSendArray((byte)DFU_Command.CMD_FW_UPDATE_SEND, data));
                    if (dfu_Thread != null)
                    {
                        dfu_Thread.Abort();
                        //dfu_Thread = null;
                    }
                }
                else
                {
                    for (k = 0; k < 4; k++)
                    {
                        for (i = 0; i < 16; i++)
                        {
                            data[i] = OriginalFileDatas[send_dfu_Length++];
                            p_buf_receive[i] = data[i];
                        }
                        // SendSerialData(MakeSendArray((byte)DFU_Command.CMD_FW_UPDATE_SEND, data));
                        serial_show_recv_data(p_buf_receive);
                        //if (0 == (i % 16))
                        //{
                        //    receive_LOG("" + "\r\n");
                        //}
                        //else
                        //{
                        //    receive_LOG("" + " ");
                        //}
                        //receive_LOG("" + data[i].ToString("X2"));
                    }
                    FileLength -= 64;
                }

                dfu_upgrade_progress();
                //  Thread.Sleep(1000);
            }
        }

        private void Button_start_transform_Click(object sender, EventArgs e)
        {
            if (comboBox_PathAndFile.Text == "")
            {
                MessageBox.Show("请选择bin文件!");

                return;
            }
            if (dfu_Thread != null)
            {
                dfu_Thread.Abort();
                dfu_Thread = null;
            }
            dfu_Thread = new Thread(dfu_StartUpGradeProcess);
            dfu_Thread.Start();
        }

        int length;

        private void TextBox_txt_show_recv_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_show_recv_clear()
        {
            //if (chk_recv_file.Checked)
            //{
            //    chk_recv_file.Checked = false;
            //}
            //else
            {
                textBox_txt_show_recv.Clear();
              //  textBox_txt_show_recv.Text = "";
            }

            //count_recv = 0;
            //slab_recv.Text = "接收:" + count_recv.ToString();
            //count_send = 0;
            //slab_send.Text = "发送:" + count_send.ToString();
        }


        private void Lbl_recv_clear_Click(object sender, EventArgs e)
        {
            txt_show_recv_clear();
        }

        private string byte_to_hex(byte[] buffer)
        {
            int i;
            string str_tmp = "";

            for (i = 0; i < buffer.Length; i++)
            {
                str_tmp += buffer[i].ToString("X2") + " ";
            }

            return str_tmp;
        }

        private void show_one_data_or_char(string[] strs)
        {

        }

        //private void serial_show_16_data(byte[] buffer)
        //{
        //    string str_tmp = "";
        //    int count_num = 0;

        //    if (chk_recv_hex.Checked)
        //    {
        //        str_tmp += byte_to_hex(buffer);
        //    }
        //    else
        //    {
        //        str_tmp += Encoding.Default.GetString(buffer);
        //    }

            
        //    string[] strs = str_tmp.Split('\b');
        //    int i;
        //    int k;
        //    count_num = strs.Count();


        //    for (k = 0; k < count_num / 16; k++)
        //    {
        //        for(i = 0; i < 16; i++)
        //        {
        //            this.textBox_txt_show_recv.Invoke(
        //                new MethodInvoker(delegate
        //                {
        //                    this.textBox_txt_show_recv.AppendText(strs[i]);
        //                }
        //                )
        //            );
        //        }
        //        this.textBox_txt_show_recv.Invoke(
        //            new MethodInvoker(delegate
        //            {
        //                this.textBox_txt_show_recv.AppendText("\r\n");
        //            }
        //            )
        //        );
        //    }
        //        //for (i = 0; i < strs.Count(); i++)
        //        //{
        //        //    this.textBox_txt_show_recv.Invoke(
        //        //        new MethodInvoker(delegate
        //        //        {
        //        //            this.textBox_txt_show_recv.AppendText(strs[i]);
        //        //        }
        //        //        )
        //        //    );
        //        //}
        //}

        private void serial_show_recv_data(byte[] buffer)
        {
            string str_tmp = "";

            //if (chk_recv_time.Checked)
            //{
            //    if (tn_show_time == 0)
            //    {
            //        if (txt_show_recv.Text.Length > 0)
            //        {
            //            str_tmp += "\r\n";
            //        }
            //        str_tmp += "【" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "】";
            //    }

            //    tn_show_time = 10;
            //}
            if (chk_recv_hex.Checked)
            {
                str_tmp += byte_to_hex(buffer);
            }
            else
            {
                str_tmp += Encoding.Default.GetString(buffer);
            }

            //if (_recv_file)
            //{
            //    File.AppendAllText(recv_file_path, str_tmp);
            //}
            //else
            {
                string[] strs = str_tmp.Split('\b');
                int i;

                for (i = 0; i < strs.Count(); i++)
                {
                    //if ((textBox_txt_show_recv.TextLength >= 1) && (i > 0))
                    //{
                    //    string str_select = "";
                    //    textBox_txt_show_recv.Select(textBox_txt_show_recv.TextLength - 1, 1);
                    //    if (textBox_txt_show_recv.SelectedText[0] == '\n')
                    //    {
                    //        if ((textBox_txt_show_recv.TextLength >= 2) && (textBox_txt_show_recv.Text[textBox_txt_show_recv.TextLength - 2] == '\r'))
                    //        {
                    //            textBox_txt_show_recv.Select(textBox_txt_show_recv.TextLength - 2, 2);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        byte[] byte_tmp = Encoding.Default.GetBytes(textBox_txt_show_recv.SelectedText);
                    //        if (byte_tmp.Length > 1)
                    //        {
                    //            byte[] byte_select = new byte[byte_tmp.Length - 1];
                    //            Array.Copy(byte_tmp, byte_select, byte_select.Length);
                    //            str_select = Encoding.Default.GetString(byte_select);
                    //        }
                    //    }
                    //    textBox_txt_show_recv.SelectedText = str_select;
                    //}

                    //if (strs[i].LastIndexOf("\x1B[2K") >= 0)
                    //{
                    //    strs[i] = strs[i].Substring(strs[i].LastIndexOf("\x1B[2K") + "\x1B[2K".Length);

                    //    int pos = textBox_txt_show_recv.Text.LastIndexOf("\r\n");
                    //    if (pos >= 0)
                    //    {
                    //        pos += "\r\n".Length;
                    //        textBox_txt_show_recv.Select(pos, textBox_txt_show_recv.Text.Length - pos);
                    //        textBox_txt_show_recv.SelectedText = "";
                    //    }
                    //    else
                    //    {
                    //        textBox_txt_show_recv.Text = "";
                    //    }
                    //}

                    // textBox_txt_show_recv.AppendText(strs[i]);
                    //if (0x0a == strs[i].ToString("X2"))
                    //{
                        
                    //}
                    //else
                    {
                        this.textBox_txt_show_recv.Invoke(
                            new MethodInvoker(delegate
                                {
                                        //  this.textBox_txt_show_recv.AppendText(strs[i] + "\r\n");
                                        this.textBox_txt_show_recv.AppendText(strs[i]);
                                }
                            )
                        );
                    }
                }
                this.textBox_txt_show_recv.Invoke(
                    new MethodInvoker(delegate
                    {
                        //  this.textBox_txt_show_recv.AppendText(strs[i] + "\r\n");
                        this.textBox_txt_show_recv.AppendText("\r\n");
                    }
                    )
                );
            }
        }

        private void Chk_recv_show_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ProgressBar1_Click(object sender, EventArgs e)
        {

        }

        private void Dfu_serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int n = dfu_serialPort.BytesToRead;
            byte[] buf = new byte[n];
            dfu_serialPort.Read(buf, 0, n);

            arraybuffer.AddRange(buf);
            if (chk_recv_show.Checked)
            {
                serial_show_recv_data(buf);
            }
            DFU_RECEIVE_DataProc(arraybuffer.ToArray());
        }

        private void DFU_RECEIVE_DataProc(byte[] data)
        {
            byte[] buf = new byte[data.Length];
            Array.Copy(data, buf, data.Length);

            try
            {
                if (buf.Length > 17)
                {
                    for (int i = 0; i < buf.Length; i++)
                    {
                        if (buf[i] == 0xAA && buf[i + 1] == 0x55)
                        {
                            length = (buf[i + 12]) + (buf[i + 13] << 8) + 14;
                            if (buf.Length >= (length + i))
                            {
                                byte checkSum = buf[length + i - 1];
                                byte[] validFrame = new byte[length];

                                Array.Copy(buf, i, validFrame, 0, validFrame.Length);

                                byte calcCRC = ProcTestData.caculatedCRC(validFrame, validFrame.Length - 1);

                                //if (X6MsgDebug)
                                //{
                                //    string receive = "";
                                //    for (int j = 0; j<validFrame.Length; j++)
                                //    {
                                //        receive += validFrame[j].ToString("X2") + " ";
                                //    }
                                //    //LOG("Receive: " + receive);

                                //}

                                if (calcCRC == checkSum)
                                {
                                    arraybuffer.Clear();

                                    byte cmd = validFrame[16];

                                    switch (cmd)
                                    {
                                        //case (byte) X6Command.TestMode://测试模式请求
                                        //    X6MessageTestModeHandle(validFrame);
                                        //    Thread.Sleep(500);
                                        //    break;

                                        case (byte)DFU_Command.CMD_FW_UPDATE_REQ:

                                            break;
                                        case (byte) DFU_Command.CMD_FW_UPDATE_SEND:
                                            
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    //LOG("recv data err");
                                    //if (X6MsgDebug)
                                    //{
                                    //    string receive = "";
                                    //    for (int j = 0; j<validFrame.Length; j++)
                                    //    {
                                    //        receive += validFrame[j].ToString("X2") + " ";
                                    //    }
                                    //    LOG("Receive: " + receive);
                                    //}
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }
    }
}
