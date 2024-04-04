using SQLiteDemo.Core;
using SQLiteDemo.Data;

namespace SQLiteDemo
{
    public partial class Form1 : Form
    {
        private IDataHelper<Note> dataHelperNote;
        private IDataHelper<Users> dataHelperUsers;
        public Form1()
        {
            InitializeComponent();
            dataHelperNote = new NoteEF();
            dataHelperUsers = new UsersEF();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.DataSource = dataHelperNote.GetAllData();
            dataGridView1.Columns[0].HeaderText = "المعرف";
            dataGridView1.Columns[1].HeaderText = "العنوان";
            dataGridView1.Columns[2].HeaderText = "الوصف";
            dataGridView1.Columns[3].HeaderText = "طابع زمني";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Note note = new Note
            {
                AddedDate = DateTime.Now,
                Description = richTextBox1.Text,
                Title = textBoxTitle.Text,
            };

            dataHelperNote.Add(note);
            LoadData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            dataHelperNote.Delete(Id);
            LoadData();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            Note note = new Note
            {
                Id = Id,
                AddedDate = DateTime.Now,
                Description = richTextBox1.Text,
                Title = textBoxTitle.Text,
            };

            dataHelperNote.Update(note);
            LoadData();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dataHelperNote.Search(textBoxSearch.Text);
            dataGridView1.Columns[0].HeaderText = "المعرف";
            dataGridView1.Columns[1].HeaderText = "العنوان";
            dataGridView1.Columns[2].HeaderText = "الوصف";
            dataGridView1.Columns[3].HeaderText = "طابع زمني";
        }
    }
}
