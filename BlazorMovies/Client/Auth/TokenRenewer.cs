using System;
using System.Timers;

namespace BlazorMovies.Client.Auth {
	public class TokenRenewer : IDisposable {
        Timer timer;
        private readonly ILoginService _login;

        public TokenRenewer(ILoginService loginService) {
            _login = loginService;
        }

        public void Initiate() {
            timer = new Timer();
            timer.Interval = 1000 * 60 * 4; // 4 minutes
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            Console.WriteLine("Timer elapsed: " + DateTime.Now);
            _login.TryRenewToken();
        }

        public void Dispose() {
            timer?.Dispose();
        }
    }
}