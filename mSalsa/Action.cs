//=-------
// Copyright 2005, Irma Amaya
// 
//   Provided as is, with no warrenty, etc.
//   License is granted to use, copy, modify, 
//   with or without credit to me, just don't
//   blame me if it doesn't work.
//=-------

using System;

using agsXMPP;
using agsXMPP.protocol;
using agsXMPP.protocol.iq;
using agsXMPP.protocol.iq.roster;
using agsXMPP.protocol.iq.agent;
using agsXMPP.Xml.DomParser;

using System.Threading;

namespace mSalsa
{
	/// <summary>
	/// Action of the Agent. 
	/// </summary>
	/// <remarks>
	/// The developer specifies in this class the agent's action or set of actions of the Agent.
	/// </remarks>
	public abstract class Action
	{
		/// <summary>
		/// Jabber Client instance.
		/// </summary>
		private JabberClient jc;

		/// <summary>
		/// Class Action constructor
		/// </summary>		
		public Action()	{}
		
		/// <summary>
		/// This method is implemented by the developer to specify the action of the Agent
		/// </summary>
		public abstract void execute();

		/// <summary>
		/// Sends a message to Request information to other Agent.		 		
		/// </summary>
		/// <param name="to">Instant message address of the other Agent.</param>
		/// <param name="body">Simple message.</param>
		/// <param name="type">Type of the information to be requested.</param>
		/// <param name="param">Set of xml tags specifying other information the the other agent need to retrieved the information requested.</param>		
		public void sendRequest(string to, string body, string type, string param)
		{
			try
			{
				string parameters = "<type>" + type + "</type>" + param;
				this.sendMessage(to, body, "request", parameters);
			}
			catch{;}
		}

		/// <summary>
		/// Sends a message that Responds to a Request information of other Agent.
		/// </summary>
		/// <param name="to">Instant message address of the other Agent.</param>
		/// <param name="body">Simple message.</param>
		/// <param name="type">Type of the information send to other Agent.</param>
		/// <param name="param">Set of xml tags specifying other information the the other agent need to send the information requested.</param>
		public void sendResponse(string to, string body, string type, string param)
		{
			try
			{
				string parameters = "<type>" + type + "</type>" + param;
				this.sendMessage(to, body, "response", parameters);
			}
			catch{;}
		}

		/// <summary>
		/// Sends notification info.
		/// </summary>
		/// <param name="to">Instant message address of the other Agent.</param>
		/// <param name="body">Notification message.</param>
		/// <param name="type">Type of the information send to other Agent.</param>
		/// <param name="param">Set of xml tags specifying other information the the other agent need to send the notificacion.</param>
		public void sendNotificationInfo(string to, string body, string type, string param)
		{
			try
			{
				string parameters = "<type>" + type + "</type>" + param;
				this.sendMessage(to, body, "notificationInfo", parameters);
			}
			catch{;}
		}

		/// <summary>
		/// Sends a message to request to execute a command or action to other Agent.
		/// </summary>
		/// <param name="to">Instant message address of the other Agent.</param>
		/// <param name="body">Simple message.</param>
		/// <param name="command">Type of the command or action. It can be the name of the command.</param>
		/// <param name="param">Set of xml tags specifying other information the the other agent need to execute the command.</param>
		public void sendCommandRequest(string to, string body, string command, string param)
		{
			try
			{
				string parameters = "<command>" + command + "</command>" + param;
				this.sendMessage(to, body, "command", parameters);
			}
			catch{;}
		}

		/// <summary>
		/// Send a message to other Agent.
		/// </summary>
		/// <remarks>
		/// Sends a SALSA message.
		/// </remarks>
		/// <param name="to">Instant message address of the other Agent.</param>
		/// <param name="body">Simple message.</param>
		/// <param name="type">Type of message to be sent.</param>
		/// <param name="param">Set of xml tags specifying other information of the message.</param>
		public void sendMessage(string to, string body, string type, string param)
		{
			string from = jc.MyJID.Bare;
			string xml = "<message to='" + to + "' from='" + from +"'>" +
				"<body>" + body + "</body>" +
				"<x xmlns='x:" + type + "'>" +
				"<params>"+
				param +
				"</params>" +
				"</x>" +
				"</message>";
			jc.Send(xml);
		}

		/// <summary>
		/// Sends a simple message to other Agent.
		/// </summary>
		/// <remarks>
		/// Sends a simple xml message
		/// </remarks>
		/// <param name="from">Instant message address of this Agent.</param>
		/// <param name="to">Instant message address of the other Agent.</param>
		/// <param name="body">Simple message.</param>
		public void sendMessage(string from, string to, string body )
		{
			string xml="<message to='"+to+"' from='"+ from +"' id='by:"+from+"'>"+body+"</message>";
			jc.Send(xml);
		}

		/// <summary>
		/// Sends a presence message.
		/// </summary>
		/// <param name="status">State of the agent: online, available, ...</param>
		/// <param name="nickUser">Name of the agent.</param>
		/// <param name="area">Area of the building in which this agent is located.</param>
		/// <param name="location">Room or specific place of the area in which this agent is located.</param>
		/// <param name="typeOfAgent">Type of agent: user or service.</param>
		public void sendPresence(string status, string nickUser, string area, string location, string typeOfAgent)
		{
			String param = "<params>" +
					   "<user>" + nickUser + "</user>" +
					   "<area>" + area + "</area>" +
					   "<location>" + location + "</location>" +
					   "<type>" + typeOfAgent + "</type>" +
					   "</params>";

			string presence = "<presence>" + param + "</presence>";
			jc.Send(presence);
		}


		/// <summary>
		/// This method make an instance of the Jabber Client for Class Action.
		/// </summary>
		/// <param name="jClient">Jabber Client Instance</param>
		public void setProxyBroker(JabberClient jClient)	
		{
			jc = jClient;
		}
	}
}
