//  * **************************************************************************
//  * Copyright (c) McCreary, Veselka, Bragg & Allen, P.C.
//  * This source code is subject to terms and conditions of the MIT License.
//  * A copy of the license can be found in the License.txt file
//  * at the root of this distribution.
//  * By using this source code in any fashion, you are agreeing to be bound by
//  * the terms of the MIT License.
//  * You must not remove this notice from this software.
//  * **************************************************************************

using System;

using JetBrains.Annotations;

namespace MvbaCore
{
	public class NotificationMessage : IEquatable<NotificationMessage>
	{
		[StringFormatMethod("messageFormatString")]
		public NotificationMessage(NotificationSeverity severity, [NotNull] string messageFormatString,
		                           params object[] messageParameters)
		{
			Severity = severity;
			Message = String.Format(messageFormatString, messageParameters);
		}

		public NotificationMessage(NotificationSeverity severity, [NotNull] string message)
		{
			Severity = severity;
			Message = message;
		}

		public string Message { get; private set; }
		public NotificationSeverity Severity { get; private set; }

		[Pure]
		[ContractAnnotation("other:null => false")]
		public virtual bool Equals([CanBeNull] NotificationMessage other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}
			if (ReferenceEquals(this, other))
			{
				return true;
			}
			return Equals(other.Severity, Severity) && Equals(other.Message, Message);
		}

		[Pure]
		[ContractAnnotation("obj:null => false")]
		public override bool Equals([CanBeNull] object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}
			if (ReferenceEquals(this, obj))
			{
				return true;
			}
			if (obj.GetType() != typeof(NotificationMessage))
			{
				return false;
			}
			return Equals((NotificationMessage)obj);
		}

		[Pure]
		public override int GetHashCode()
		{
			unchecked
			{
				return Severity.GetHashCode() * 397 ^ (Message != null ? Message.GetHashCode() : 0);
			}
		}

		[Pure]
		public override string ToString()
		{
			return Severity + ": " + Message;
		}
	}
}