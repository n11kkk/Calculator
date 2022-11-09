using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Calculator;

public partial class ExercisePage : ContentPage
{
    HttpClient _client;
    JsonSerializerOptions _serializerOptions;
    public ExercisePage()
    {
        InitializeComponent();
        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    private readonly string ExerciseApi = "https://localhost:7161/Exercise";
    public class Exercise
    {
        public int[]? FirstNum { get; set; }
        public int[]? SecondNum { get; set; }

        public string[]? Operators { get; set; }
        public int[]? Answers { get; set; }

        public int[][]? Options { get; set; }

    }


   
    }
}