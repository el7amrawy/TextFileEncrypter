namespace FileEncrypter
{
    public partial class Form1 : Form
    {
        private byte[] _iv = Convert.FromBase64String("UgWdxzws+ilXTsjzU5pjsg==");
        private byte[] _key = Convert.FromBase64String("pHiB9SU4/DY2JUiqImxIkm7MdI0FXsmUjo6/5K4a90A=");
        public Form1()
        {
            InitializeComponent();
            //AesEncrypt.EncryptFile(@"C:\Users\Aly\Desktop\Screenshot (3).png", _iv,_key);
            AesEncrypt.DecryptFile(@"C:\Users\Aly\Desktop\Screenshot (3).enc", _iv, _key);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            richTextEncrypt.Select();
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string plainText = richTextEncrypt.Text;
            richTextDecrypt.Text = Convert.ToBase64String( AesEncrypt.Encrypter(plainText, _iv, _key));
            richTextEncrypt.Text = string.Empty;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            var cipherText= Convert.FromBase64String(richTextDecrypt.Text);
            richTextEncrypt.Text = AesEncrypt.Decrypter(cipherText, _iv,_key);
        }
    }
}
