using Calculator.Themes;

namespace Calculator;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
	}
    void OnDark(object sender, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();

            mergedDictionaries.Add(new DarkTheme());

        }
    }

    void OnLight(object sender, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();

            mergedDictionaries.Add(new LightTheme());

        }
    }

    void OnGreen(object sender, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();

            mergedDictionaries.Add(new GreenTheme());

        }
    }
    void OnPink(object sender, EventArgs e)
    {
        ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
        if (mergedDictionaries != null)
        {
            mergedDictionaries.Clear();

            mergedDictionaries.Add(new PinkTheme());

        }
    }
}