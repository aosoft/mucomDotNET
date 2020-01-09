﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mucomDotNET.Driver
{
    public class SoundWork
    {
        public CHDAT[] CHDAT = new CHDAT[]
        {
            new CHDAT()//FM Ch1
            ,new CHDAT()//FM Ch2
            ,new CHDAT()//FM Ch3

            ,new CHDAT()//SSG Ch1
            ,new CHDAT()//SSG Ch2
            ,new CHDAT()//SSG Ch3

            ,new CHDAT()//Drums Ch

            ,new CHDAT()//FM Ch4
            ,new CHDAT()//FM Ch5
            ,new CHDAT()//FM Ch6

            ,new CHDAT()//ADPCM Ch
        };

        public ushort[] PREGBF = null;
        public ushort[] INITPM = null;
        public ushort[] DETDAT = null;
        public byte[] DRMVOL = null;
        public byte[] OP_SEL = null;
        public byte[] TYPE1 = null;
        public byte[] TYPE2 = null;
        public byte DMY = 0;       //DB    8
        public ushort[] FNUMB = null;
        public ushort[] SNUMB = null;
        public ushort[] PCMNMB = null;
        public byte[] SSGDAT = null;


        internal void Init()
        {
            CHDAT[0].lengthCounter = 1;
            CHDAT[0].instrumentNumber = 24;
            CHDAT[0].volume = 10;

            CHDAT[1].lengthCounter = 1;
            CHDAT[1].instrumentNumber = 24;
            CHDAT[1].volume = 10;
            CHDAT[1].channelNumber = 1;

            CHDAT[2].lengthCounter = 1;
            CHDAT[2].instrumentNumber = 24;
            CHDAT[2].volume = 10;
            CHDAT[2].channelNumber = 2;


            CHDAT[3].lengthCounter = 1;
            CHDAT[3].instrumentNumber = 0;
            CHDAT[3].volume = 8;
            CHDAT[3].volReg = 8;
            CHDAT[3].channelNumber = 0;

            CHDAT[4].lengthCounter = 1;
            CHDAT[4].instrumentNumber = 0;
            CHDAT[4].volume = 8;
            CHDAT[4].volReg = 9;
            CHDAT[4].channelNumber = 2;

            CHDAT[5].lengthCounter = 1;
            CHDAT[5].instrumentNumber = 0;
            CHDAT[5].volume = 8;
            CHDAT[5].volReg = 10;
            CHDAT[5].channelNumber = 4;


            CHDAT[6].lengthCounter = 1;
            CHDAT[6].volume = 10;
            CHDAT[6].channelNumber = 2;


            CHDAT[7].lengthCounter = 1;
            CHDAT[7].volume = 10;
            CHDAT[7].channelNumber = 2;

            CHDAT[8].lengthCounter = 1;
            CHDAT[8].volume = 10;
            CHDAT[8].channelNumber = 2;

            CHDAT[9].lengthCounter = 1;
            CHDAT[9].volume = 10;
            CHDAT[9].channelNumber = 2;


            CHDAT[10].lengthCounter = 1;
            CHDAT[10].volume = 10;
            CHDAT[10].channelNumber = 2;

            PREGBF = new ushort[9];
            INITPM = new ushort[] { 0, 0, 0, 0, 0, 56, 0, 0, 0 };
            DETDAT = new ushort[4] { 0, 0, 0, 0 };
            DRMVOL = new byte[6] { 0xc0, 0xc0, 0xc0, 0xc0, 0xc0, 0xc0 };
            OP_SEL = new byte[4] { 0xa6, 0xac, 0xad, 0xae };
            DMY = 8;
            TYPE1 = new byte[] { 0x032, 0x044, 0x046 };
            TYPE2 = new byte[] { 0x0AA, 0x0A8, 0x0AC };
            FNUMB = new ushort[] {
                 0x026A    ,0x028F    ,0x02B6    ,0x02DF
                ,0x030B    ,0x0339    ,0x036A    ,0x039E
                ,0x03D5    ,0x0410    ,0x044E    ,0x048F
            };
            SNUMB = new ushort[] {
                0x0EE8    ,0x0E12    ,0x0D48    ,0x0C89
                ,0x0BD5    ,0x0B2B    ,0x0A8A    ,0x09F3
                ,0x0964    ,0x08DD    ,0x085E    ,0x07E6
            };
            PCMNMB = new ushort[] {
                0x49BA+200,0x4E1C+200,0x52C1+200,0x57AD+200
                ,0x5CE4+200,0x626A+200,0x6844+200,0x6E77+200
                ,0x7509+200,0x7BFE+200,0x835E+200,0x8B2D+200
            };
            SSGDAT = new byte[]{
                255,255,255,255,0,255 // E
                ,255,255,255,200,0,10
                ,255,255,255,200,1,10
                ,255,255,255,190,0,10
                ,255,255,255,190,1,10
                ,255,255,255,170,0,10
                ,40,70,14,190,0,15
                ,120,030,255,255,0,10
                ,255,255,255,225,8,15
                ,255,255,255,1,255,255
                ,255,255,255,200,8,255
                ,255,255,255,220,20,8
                ,255,255,255,255,0,10
                ,255,255,255,255,0,10
                ,120,80,255,255,0,255
                ,255,255,255,220,0,255 // 6*16
            };

        }
    }

    public class CHDAT
    {
        public int lengthCounter = 1;//DB	1	        ; LENGTH ｶｳﾝﾀｰ      IX+ 0
        public int instrumentNumber = 24;//DB	24	        ; ｵﾝｼｮｸ ﾅﾝﾊﾞｰ		1
        public int dataAddressWork = 0;//DW	0	        ; DATA ADDRES WORK	2,3
        public int dataTopAddress = 0;//DW	0	        ; DATA TOP ADDRES	4,5
        public int volume = 10;//DB	10	        ; VOLUME DATA		6
        public int softEnvelopeFlag = 0;
        //			        ; bit 4 = attack flag
        //                  ; bit 5 = decay flag
        //                  ; bit 6 = sustain flag
        //                  ; bit 7 = soft envelope flag
        public int algo = 0;//DB	0	        ; ｱﾙｺﾞﾘｽﾞﾑ No.      7
        public int volReg = 0;//DB	8   	    ; VOL.REG.No.       7
        public int channelNumber = 0;//DB    0	        ; ﾁｬﾝﾈﾙ ﾅﾝﾊﾞｰ          	8
        public int detune = 0;//DW	0	        ; ﾃﾞﾁｭｰﾝ DATA		9,10
        public int TLlfo = 0;//DB	0	        ; for TLLFO		11
        public int softEnvelopeCounter = 0;//DB	0   	    ; SOFT ENVE COUNTER	11
        public int reverb = 0;//DB	0	        ; for ﾘﾊﾞｰﾌﾞ		12
        //public int[] softEnvelopeDummy = new int[5];//DS	5	        ; SOFT ENVE DUMMY	13-17
        public int[] softEnvelopeParam = new int[6];//SOFT ENVE		12-17    //KUMA:  12:AL 13:AR 14:DR 15:SR 16:SL 17:RR
        public int quantize = 0;//DB	0	        ; qｵﾝﾀｲｽﾞ		18
        public int lfoDelay = 0;//DB	0	        ; LFO DELAY		19
        public int lfoDelayWork = 0;//DB	0	        ; WORK			20
        public int lfoCounter = 0;//DB	0	        ; LFO COUNTER		21
        public int lfoCounterWork = 0;//DB	0	        ; WORK			22
        public int lfoDelta = 0;//DW	0	        ; LFO ﾍﾝｶﾘｮｳ 2BYTE	23,24
        public int lfoDeltaWork = 0;//DW	0	        ; WORK			25,26
        public int lfoPeak = 0;//DB	0	        ; LFO PEAK LEVEL	27
        public int lfoPeakWork = 0;//DB	0	        ; WORK			28
        public int fnum = 0;//DB	0	        ; FNUM1 DATA		29
        public int bfnum2 = 0;//DB	0	        ; B/FNUM2 DATA		30
        public bool lfoflg = false;//DB	00000001B	; bit 7=LFO FLAG	31
        public bool keyoffflg = false;//			        ; bit	6=KEYOFF FLAG
        public bool lfoContFlg = false;//                  ; 5=LFO CONTINUE FLAG
        public bool tieFlg = false;//			        ; 4=TIE FLAG
        public bool muteFlg = false;//                  ; 3=MUTE FLAG
        public bool lfo1shotFlg = false;//                  ; 2=LFO 1SHOT FLAG
        //                  ;
        public bool loopEndFlg = false;//			        ; 0=1LOOPEND FLAG
        public int beforeCode = 0;//DB 	0           ; BEFORE CODE		32
        public bool tlLfoflg = false;//DB	0	        ; bit	6=TL LFO FLAG     33
        public bool reverbFlg = false;//			        ; 5=REVERVE FLAG
        public bool reverbMode = false;//                  ; 4=REVERVE MODE
        public int returnAddress = 0;//DW	0	        ; ﾘﾀｰﾝｱﾄﾞﾚｽ	34,35
        public int reserve = 0;//DB	0,0         ; 36,37 (ｱｷ)

    }
}