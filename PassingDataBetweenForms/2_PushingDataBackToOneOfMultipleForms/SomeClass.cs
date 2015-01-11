namespace PushingDataBackToOneOfMultipleForms
{
    public class SomeClass
    {
        public void SomeMethod()
        {
            using (var detailForm = new DetailForm(this))
            {
                detailForm.ShowDialog();
            }
        }

        public string Name { get; set; }
    }
}
