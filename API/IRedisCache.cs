public interface IRedisCache
    {
        byte[] GetUserRegistrationState(string key);
        bool AddRegistration(string value);
        public void deleteRegister(int logId);

        public void ChangePassword(int logiId, string newPassword);
    }