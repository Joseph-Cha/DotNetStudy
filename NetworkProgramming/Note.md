## 정리 

### 1. 정보 클래스
IPAddress, IPHostEntry, IPEndPoint,Dns는 클래스이지만 구조체 정도 수준
서로 연관

IPAddress : 단순 ip\
-> IPHostEntry : ip + hostname\
-> IPEndPoint : ip + port\
-> Dns : ip + domain\
IPAddress.Parse("ip주소") : IPAddress에 ip 주소를 저장

### 2. 연결 클래스
**Socket 기반(Winsock)**
- TCP
   1. TcpListner : 서버
   2. TcpClient : 서버 & 클라이언트
- UDP
   1. UdpClient : 서버 & 클라이언트
   

1. TCP
   1. TcpListener(서버)
      - 서버란 프로그램과 컴퓨터
      - 서버는 항상 대기 상태
      - 클라이언트 연결을 대기(수동적)
      - 대기상태의 코드가 들어감(TcpListener 메소드)
      - TcpListener의 역할
        - 클라이언트 연결 대기
        - TcpClient 생성
       1. 대기 상태
          - 생성자
            - 서버 ip 주소와 포트 번호 설정
          - TcpListener.Start와 TcpListener.Stop
            - 대기상태 시작과 정지
            - TcpListener.AcceptTcpClient() 이전실행
          - TcpListener.AcceptTcpClient()
            - 클라이언트 요청 대기 및 **TcpClient생성 -> 연결 수락**
   2. TcpClient
      - 특징
        - 서버와 클라이언트 모두 사용
      - 역할
        - 서버와 클라이언트 연결 및 요청
      - TcpClient 생성자
        -호스트명(도메인명) or IP 주소와 포트 설정 -> 연결 통로 설정
      - 생성자 외의 연결 요청 메소드
        - 이미 생성된 TcpClient의 연결 주소와 포트 변경하는 TcpClient의 메소드
        - public void Connect(IPAddress address, int port)
        - public void Connect(IPAddress[] address, int port)
        - public void Connect(IPEndPoint remoteEP)
        - **public void Connect(string hostname, int port)**
      - 연결 해제
        - TcpClient.Close()
      - 데이터전송 스트림
        - NetworkStream(데이터 전송을 돕는 모듈)
          - public NetworkStream GetStream() 
            -  TcpClient의 내장 메소드
            -  현재 연결된 TcpClient와 데이터를 주고 받기 위해 사용
          - NetworkStream.Read() / NetworkStream.Write()

요약\
TcpListener에서 서버를 오픈해 놓으면(해당 IP와 포트를 오픈) TcpClient에서 해당 서버에 접근한다.(TcpClient 생성자)
NetworkStream을 통해 서버와 클라이언트 간에 데이터를 주고 받을 수 있다.


### 3. 전송 클래스
- NetworkStream
  - 역할\
    TCP 연결에서 데이터 송수신 스트림
    모든 데이터 단위는 byte
  - 스트림에서 데이터 쓰기\
    public override void Write()
  - 스트림에서 데이터 읽기\
    public override int Read()
    리턴값 : 읽은 바이트 수(리턴값이 0이면 읽을 데이터가 없음
  - 속성
    1. NetworkStream.CanRead
      public override bool CanRead{ get; }
    2. NetworkStream.CanWrite
      public override bool CanWrite{ get; }
    => 스트림에서 데이터 읽고 쓸 수 있는지 확인
- StreamWriter
  - 역할\
    문자열의 끝에 종결자('\n', '\r\n', '\r')를 붙여 쓰기
  - StreamWriter 생성자\
    스트림 설정\
    public StreamWriter(Stream stream)\
    NetWorkStream
  - 종결자와 함께 쓰기 (하나의 string 값)\
    StreamWriter.WriteLine() // 가장 기본적인 형태\
    public virtual void WriterLine(bool value)\
    public virtual void WriterLine(char value)\
    public virtual void WriterLine(double value)\
    public virtual void WriterLine(int value)\
    public virtual void WriterLine(long value)\
    public virtual void WriterLine(float value)\
    public virtual void WriterLine(string value)
  - StreamWriter 해제\
    StreamWriter.Close()\
    NetworkStream ns = tcpClient.GetStream();
    using(StreamWriter sw = new StreamWriter(ns))\
    {

    }
- StreamReader
  - 역할\
    StreamWriter에서 전달하는 문자열을\
    종결자 단위로 읽기
  - 생성자\
    스트림 설정\
    public StreamReader(Stream stream)\
    NetworkStream ns = tcpClient.GetStream();\
    using (StreamReader sr = new StreamRead(ns))\
    {

    }
  - StreamReader.ReadLine()\
    종결자 단위로 읽기 // 한 문장 단위로 읽기\
    public override string Readline()\
    리턴값이 null이면 읽을 것이 없음
  - StreamReader 해제\
    SteamReader.Clsoe()\
    -> using문 사용
- 중간 정리 
  - NetworkStream은 기본 전달 경로 제공
  - StreamWriter와 StreamReader\
    string형 + 종결자('\n', '\r\n', '\r')\
    -> 데이터를 다루기 쉽다.
  - NetworkStream + StreamWriter, StreamReader 사용\
    -> 코드적인 편의 -> 생상성 증가 
- Stream 입출력에 대해
  - 이진 파일 / BinaryWriter, BinaryReader\
    텍스트 파일 / StreamReader, StreamWriter
    - 공통점\
      0과 1로된 데이터로 구성
    - 차이점\
      임의의 데이터형 해석 -> 이진\
      1바이트 단위형 해석 -> 일반
- BinaryWriter
  - 역할\
    NetworkStream을 통해 임의의 데이터 전송\
    기본 0, 1
  - System.IO namespace 선언 필요
  - 생성자\
    연결할 NetworkStream 설정\
    public BinaryWriter(Stream output)\
    NetworkStream ns = tcpClient.GetStream();\
    using (BinaryWriter bw = new BinaryWriter(ns))\
    {

    }
  - BinaryWriter.Writer() -> 가장 중요!!\
    임의의 데이터형 쓰기\
    public virtual void Write(bool value)\
    public virtual void Write(byte value)\
    public virtual void Write(char ch)\
    public virtual void Write(int value)\
    public virtual void Write(long value)\
    public virtual void Write(float value)\
    public virtual void Write(string value)
  - BinaryWriter.Close()\
    BinaryWriter 해제\
    using 문 사용\
    using (BinaryWriter bw = new BinaryWriter(ns))\
    {

    }
  - BinaryReader
    - 생성자\
      연결할 NetworkStream 설정\
      public BinaryReader(Stream input)
    - BinaryWriter 데이터 읽기 -> 중요~~\
      BinaryReader.ReadXXX()\
      public virtual bool ReadBoolen()\
      public virtual byte ReadByte()\
      public virtual byte[] ReadBytes(int count)\
      public virtual char ReadChar()\
      public virtual char ReadChar(int count)\
      public virtual double ReadDouble()\
      public virtual int ReadInt32()\
      public virtual long RaadInt64()\
      public virtual float ReadSingle()\
      public virtual string ReadString()
    - 서버에서 보낸 데이터를 주고 받을 때 타입이 1:1로 대응이 되어야한다.\
      ex.\ 
      writer() float -> BinaryReader.ReadSingle()\
      writer() int -> BinaryReader.ReadInt32()\
      writer() string -> BinaryReader.ReadString()
    - BinaryReader 해제\
      BinaryReader.Close()
### 4. 데이터 변환 클래스와 메서드
  - System.Text.Encoding 클래스 사용
  - System.Text 기본 namespace\
    public virtual byte[] GetBytes(char[] chars)\
    public virtual byte[] GetBytes(string s)\
    public virtual char[] GetChars(byte[] bytes)\
    public virtual string GetString(byte[] bytes)

