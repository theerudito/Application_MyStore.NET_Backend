namespace Store.Utils
{
    public static class MessagesJSON
    {
        //sd
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