using System.Net.Http.Json;
using LoggerViewer.Models;

namespace LoggerViewer.Services
{
    public class LogEntryService
    {
        private readonly HttpClient _httpClient;

        public LogEntryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<LogEntry>> GetSourceLogEntriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<LogEntry>>("api/logentries/source");
        }

        public async Task<List<LogEntry>> GetDestinationLogEntriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<LogEntry>>("api/logentries/destination");
        }

        public async Task CreateSourceLogEntryAsync(LogEntry logEntry)
        {
            await _httpClient.PostAsJsonAsync("api/logentries/source", logEntry);
        }

        public async Task CreateDestinationLogEntryAsync(LogEntry logEntry)
        {
            await _httpClient.PostAsJsonAsync("api/logentries/destination", logEntry);
        }

        public async Task UpdateSourceLogEntryAsync(LogEntry logEntry)
        {
            await _httpClient.PutAsJsonAsync($"api/logentries/source/{logEntry.Id}", logEntry);
        }

        public async Task UpdateDestinationLogEntryAsync(LogEntry logEntry)
        {
            await _httpClient.PutAsJsonAsync($"api/logentries/destination/{logEntry.Id}", logEntry);
        }

        public async Task DeleteSourceLogEntryAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/logentries/source/{id}");
        }

        public async Task DeleteDestinationLogEntryAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/logentries/destination/{id}");
        }
    }
}