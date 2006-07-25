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
	/// <para>PassivePerception component of the Agent</para>
	/// </summary>
	public class PassivePerception
	{
		/// <summary>
		/// Instance of the Reasoning component.
		/// </summary>
		public Reasoning reasoning;

		/// <summary>
		/// Links this PassivePerception with an Agent.
		/// </summary>
		public PassivePerception() { }

		/// <summary>
		/// Set the reasoning component to the agent.
		/// </summary>
		/// <param name="rsn">The reasoning component</param>
		public void setReasoning(Reasoning rsn)
		{
			reasoning=rsn;
		}

		/// <summary>
		/// <para>The PassiveEntityToPerceive will notify the information received by invoking this method.</para>
		/// <para>When a SALSA message is perceived, this method will generate a SALSA event and notify it to the reasoning component of the agent.</para>
		/// </summary>
		/// <param name="input">Wraps the information perceived, which can be an XMLpresence, XMLmessage, or any other kind of object.</param>
		public void perceive(Input input) 
		{
			// If input is a message			
			if (input.data.GetType().FullName.Equals("mSalsa.XMLmessage"))
			{
				try 
				{
					XMLmessage xml_msg = (XMLmessage)input.data;
					string xml=xml_msg.msg;
					/*Debug*/
					//Console.WriteLine("-->PassivePerception: XMLMessage perceived->" + xml);

					// Parse the message
					Parser p = new Parser(xml);
					string tipoMensaje = p.getType();			
					
					//An event is generated
					Event ev = new Event(xml,this);

					// The type of event is set
					if(tipoMensaje.Equals("simpleMessage") == true)
					{
						ev.type = salsa_event_type.ArriveSimpleMessageEvent;
					}
					else if (tipoMensaje.Equals("command") == true)
					{
						ev.type = salsa_event_type.ArriveCommandEvent;
					}
					else if (tipoMensaje.Equals("response") == true)
					{
						ev.type = salsa_event_type.ArriveResponseEvent;
					}
					else if (tipoMensaje.Equals("notificationInfo") == true)
					{
						ev.type = salsa_event_type.ArriveNotificationInfoEvent;						
					}
					else if (tipoMensaje.Equals("request") == true)
					{
						ev.type = salsa_event_type.ArriveRequestEvent;
					}
					else if (tipoMensaje.Equals("contextualMsg") == true)
					{
						ev.type = salsa_event_type.ArriveContextualMsgEvent;
					}
					reasoning.think(ev.type, ev.xml); 
				}
				catch (Exception ex) 
				{
					ex.ToString();
				}
			}
			else if(input.data.GetType().FullName.Equals("mSalsa.XMLpresence"))
			{
				try {
					XMLpresence xml_pres = (XMLpresence)input.data;
					string xml=xml_pres.presence;
					/*Debug*/
					//Console.WriteLine("-->PassivePerception: XMLPresence perceived:" + xml);
		

					//An event is generated
					Event ev = new Event(xml,this);

					//The type of event is set
					/*DEBUG*/
					//Console.WriteLine("-->Event created in PassivePerception: ArrivePresenceEvent");
					ev.type = salsa_event_type.ArrivePresenceEvent;

					reasoning.think(ev.type, ev.xml);
				}
				catch(Exception ex)
				{
					ex.ToString();
				}
			} 
		}
	}
}
