//=-------
// Copyright 2005, Pedro Santana
// 
//   Provided as is, with no warrenty, etc.
//   License is granted to use, copy, modify, 
//   with or without credit to me, just don't
//   blame me if it doesn't work.
//=-------

using System;

namespace mSalsa
{
	/// <summary>
	/// Specifies the type of event generated in tha Perception component
	/// </summary>
	public enum salsa_event_type 
	{ 		
		/// <summary>
		/// State Change event.
		/// </summary>
		StateChangeEvent = 0,
		/// <summary>
		/// User Event.
		/// </summary>
		UserEvent = 1,
		/// <summary>
		/// Command Event.
		/// </summary>
		ArriveCommandEvent = 2,
		/// <summary>
		/// Response event.
		/// </summary>
		ArriveResponseEvent = 3,
		/// <summary>
		/// Notification Info Event.
		/// </summary>
		ArriveNotificationInfoEvent = 4,
		/// <summary>
		/// Request Event.
		/// </summary>
		ArriveRequestEvent = 5,
		/// <summary>
		/// contextual Message Event.
		/// </summary>
		ArriveContextualMsgEvent = 6,
		/// <summary>
		/// Component Event.
		/// </summary>
		ArriveComponentEvent  = 7,
		/// <summary>
		/// Simple Message Event.
		/// </summary>
		ArriveSimpleMessageEvent = 8,
		/// <summary>
		/// Presence Event.
		/// </summary>
		ArrivePresenceEvent = 9,
		/// <summary>
		/// Sensor Data Event.
		/// </summary>
		ArriveSensorDataEvent = 10,
	} 

	/// <summary>
	/// Event class.
	/// </summary>
	public class Event
	{		
		private salsa_event_type Type;
		private Input inp;
		private string xmlCad;

		/// <summary>
		/// Create an Event that wraps the xml message perceived.
		/// </summary>
		/// <param name="xml">Message perceived through a Client (IM client).</param>
		/// <param name="obj">Object in which the event was generated.</param>
		public Event(string xml, Object obj)
		{		
			this.xmlCad=xml;
		}

		/// <summary>
		/// Get the XML message.
		/// </summary>
		/// <value>String XML.</value>
		public string xml
		{
			get
			{
				return this.xmlCad;
			}
			set
			{
				this.xmlCad = value;
			}
		}
	

		/// <summary>
		/// Get the type of event.
		/// </summary>
		/// <value>The type of event.</value>
		public salsa_event_type type
		{
			get 
			{
				return this.Type;
			}
			
			set 
			{
				this.Type = value;
			}
		}

		/// <summary>
		/// Get the input object.
		/// </summary>
		/// <value>The input object.</value>
		public Input input
		{
			get 
			{
				return this.inp;
			}
			set 
			{
				this.inp = value;
			}
		}
	}
}
