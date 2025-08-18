namespace SisPDV.Application.Helper
{
    public static class OrderNumberHelper
    {
        public static async Task<string> GenerateNextOrderNumberAsync()
        {
            // Simulate an asynchronous operation to get the next order number
            await Task.Delay(100); // Simulating a delay for async operation
            return new Random().Next(1000, 9999).ToString(); // Generate a random order number between 1000 and 9999
        }
    }
}
