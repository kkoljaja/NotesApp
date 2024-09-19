using NotesAPI.Data;

namespace NotesUI.Components.Services
{
	public class NotesService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiUrl;
		public NotesService(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_apiUrl = configuration.GetValue<string>("ServerAPI");
		}

		public async Task AddNote(Note note)
		{
			try
			{
				await _httpClient.PostAsJsonAsync($"{_apiUrl}/Note", note);
			}
			catch
			{
                Console.WriteLine("data was not sent");
			}
		}

		public async Task<List<Note>> GetUserNotes(string username)
		{
			List<Note> notesList = new List<Note>();
			try
			{
				notesList = await _httpClient.GetFromJsonAsync<List<Note>>($"{_apiUrl}/Note?username={username}");
			}
			catch
			{
				return null;
			}
			return notesList;
		}

		public async Task UpdateNote(int id, Note note)
		{
			try
			{
				await _httpClient.PutAsJsonAsync($"{_apiUrl}/Note?id={id}", note);
			}
			catch
			{
                Console.WriteLine("data was not updated");
			}
		}

		public async Task RemoveNote(int id)
		{
			try
			{
                await _httpClient.DeleteAsync($"{_apiUrl}/Note?id={id}");
			}
			catch
			{
                Console.WriteLine("data was not removed");
            }
        }
	}
}
