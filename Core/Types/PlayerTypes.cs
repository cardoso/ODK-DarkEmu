using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public enum PacketID
    {
        CGConnect = 0x0C,
        CGLogout = 0x0F,
        CGReady = 0x11,
        CGSay = 0x15,
        CLCreatePC = 0x1A,
        CLDeletePC = 0x1B,
        CLGetPCList2 = 0x1C, // ???? IDK. Seems to be same as CLGetPCList (0x131)
        CLLogin = 0x1D,
        CLSelectPC = 0x21,
        GCSetPosition = 0x5C,
        GCUpdateInfo = 0x6F,
        LCCreatePCError = 0x72,
        LCCreatePCOK = 0x73,
        LCDeletePCError = 0x74,
        LCDeletePCOK = 0x75,
        LCLoginError = 0x76,
        LCLoginOK = 0x77,
        LCPCList = 0x78,
        LCReconnect = 0x7A,
        CLVersionCheck = 0xBC,
        LCVersionCheckOK = 0xBD,
        LCVersionCheckError = 0xBE,
        LCServerList = 0xFA,
        CLReconnectLogin = 0xFC,
        GCReconnectLogin = 0xFD,
        CLGetWorldList = 0x12E,
        LCWorldList = 0x12F,
        CLGetServerList = 0x130,
        CLGetPCList = 0x131,
        CLQueryCharacterName = 0x132,
        LCQueryResultCharacterName = 0x133,

        // internal (LG, GL, etc)
        LGIncomingConnection = 0xff01,
        GLIncomingConnectionError = 0xff02,
        GLIncomingConnectionOK = 0xff03,
        GLIncomingConnection = 0xff04
    }
    public enum ErrorID
    {
        None = -1,
        WrongUserOrPassword = 0x00,
        AlreadyConnected = 0x01,
        AlreadyRegisteredId = 0x02,
        AlreadyRegisteredSSN = 0x03,
        EmptyId = 0x04, // DkLegend Client: You're not registered member.
        SmallIdLength = 0x05,
        EmptyPassword = 0x06,
        SmallPasswordLength = 0x07,
        EmptyName = 0x08,
        EmptySSN = 0x09,
        InvalidSSN = 0x0a,
        NotFoundPlayer = 0x0b,
        NotFoundId = 0x0c,
        NotPayAccount = 0x0d,
        NotFollowAccount = 0x0e,
        AccessDenied = 0x0f, // EtcError in DkLegend Source
        IPDenied = 0x10,
        ChildGuardDenied = 0x11,
        CannotAuthorizeBilling = 0x12,
        CannotCreatePCBilling = 0x13,
        KeyExpired = 0x14,
        NotFoundKey = 0x15,
        NotAvailable = 0x16,
        DeletePCErrorGuildMaster = 0x17,
        NeedUseAgreement = 0x18,
        SpeedHackPenaltyUser = 0x19,
        InspectingServer = 0x1a
    }
}
