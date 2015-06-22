using System;
using InfinityScript;

namespace ProjectBoson
{
	public class ChatMessage
	{
		/// <summary>
		/// Gets the type of the chat where the message originates from.
		/// </summary>
		/// <value>The type of the chat.</value>
		public BaseScript.ChatType ChatType { get; private set; }

		/// <summary>
		/// Gets the chat message as-is.
		/// </summary>
		/// <value>The unmodified chat message.</value>
		public string Message { get; private set; }

		/// <summary>
		/// Gets the string array containing the message's words.
		/// This array is the result of <see cref="String.Split(char[])"/> by whitespace.
		/// </summary>
		/// <value>The words of the message.</value>
		public string[] Words { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectBoson.ChatMessage"/> class.
		/// </summary>
		/// <param name="message">Chat message.</param>
		/// <param name="chatType">Type of the chat.</param>
		public ChatMessage(string message, BaseScript.ChatType chatType)
		{
			Message = message;
			Words = message.Split(' ');
		}
	}
}

