﻿using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using Java.Util.Concurrent;
using StoryWriter.Droid.ServiceListeners;
using StoryWriter.Droid.Services;
using StoryWriter.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(AccountService))]

namespace StoryWriter.Droid.Services
{
    public class AccountService : /*PhoneAuthProvider.OnVerificationStateChangedCallbacks,*/ IAccountService
    {
        private const int OTP_TIMEOUT = 30; // seconds
        private TaskCompletionSource<bool> _phoneAuthTcs;
        private string _verificationId;

        public static AuthenticatedUser CachedUser;

        public AccountService()
        {
            LoginAnonymous();//todo
        }

        public Task<double> GetCurrentPayRateAsync()
        {
            return Task.FromResult(10d);
        }

        public Task<bool> LoginAsync(string username, string password)
        {
            var tcs = new TaskCompletionSource<bool>();
            FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(username, password)
               .ContinueWith((task) => OnAuthCompleted(task, tcs));
            return tcs.Task;
        }

        //public override void OnVerificationCompleted(PhoneAuthCredential credential)
        //{
        //    System.Diagnostics.Debug.WriteLine("PhoneAuthCredential created Automatically");
        //}

        //public override void OnVerificationFailed(FirebaseException exception)
        //{
        //    System.Diagnostics.Debug.WriteLine("Verification Failed: " + exception.Message);
        //    _phoneAuthTcs?.TrySetResult(false);
        //}

        //public override void OnCodeSent(string verificationId, PhoneAuthProvider.ForceResendingToken forceResendingToken)
        //{
        //    base.OnCodeSent(verificationId, forceResendingToken);
        //    _verificationId = verificationId;
        //    _phoneAuthTcs?.TrySetResult(true);
        //}

        //public Task<bool> SendOtpCodeAsync(string phoneNumber)
        //{
        //    _phoneAuthTcs = new TaskCompletionSource<bool>();
        //    PhoneAuthProvider.Instance.VerifyPhoneNumber(
        //        phoneNumber,
        //        OTP_TIMEOUT,
        //        TimeUnit.Seconds,
        //        Platform.CurrentActivity,
        //        this);
        //    return _phoneAuthTcs.Task;
        //}

        private void OnAuthCompleted(Task task, TaskCompletionSource<bool> tcs)
        {
            if (task.IsCanceled || task.IsFaulted)
            {
                // something went wrong
                tcs.SetResult(false);
                return;
            }
            _verificationId = null;
            tcs.SetResult(true);
        }

        //public Task<bool> VerifyOtpCodeAsync(string code)
        //{
        //    if (!string.IsNullOrWhiteSpace(_verificationId))
        //    {
        //        var credential = PhoneAuthProvider.GetCredential(_verificationId, code);
        //        var tcs = new TaskCompletionSource<bool>();
        //        FirebaseAuth.Instance.SignInWithCredentialAsync(credential)
        //            .ContinueWith((task) => OnAuthCompleted(task, tcs));
        //        return tcs.Task;
        //    }
        //    return Task.FromResult(false);
        //}

        public Task<AuthenticatedUser> GetUserAsync()
        {
            var tcs = new TaskCompletionSource<AuthenticatedUser>();
            if (CachedUser != null)
            {
                tcs.TrySetResult(CachedUser);
                return tcs.Task;
            }
            FirebaseFirestore.Instance
                .Collection("users")
                .Document(FirebaseAuth.Instance.CurrentUser.Uid)
                .Get()
                .AddOnCompleteListener(new OnAuthenticatedUserCompleteListener(tcs));

            return tcs.Task;
        }

        public Task<bool> LoginAnonymous()
        {
            var tcs = new TaskCompletionSource<bool>();

            Firebase.Auth.FirebaseAuth.Instance.SignInAnonymouslyAsync().ContinueWith((task) => OnAuthCompleted(task, tcs));
            return tcs.Task;
        }
    }
}