namespace Store.Utils
{
    public static class MessagesJSON
    {
        public static Object MessageError(string messageJSON)
        {
            return new { message = messageJSON };
        }

        public static Object MessageOK(string messageJSON)
        {
            return new { message = messageJSON };
        }
    }
}