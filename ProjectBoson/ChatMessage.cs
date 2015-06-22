using System;

namespace ProjectBoson
{
	public class ChatMessage
	{
		/// <summary>
		/// Gets the chat message as-is.
		/// </summary>
		/// <value>The chat message.</value>
		public string Message { get; private set; }

		/// <summary>
		/// Gets the string array containing the message's words.
		/// This array is the result of <see cref="String.Split(char[])"/> by whitespace.
		/// </summary>
		/// <value>The words of the message.</value>
		public string[] Words { get; private set; }

		public ChatMessage(string message)
		{
			Message = message;
			Words = message.Split(' ');
		}

		public virtual bool IsCommand()
		{
			return true;
		}
	}
}

