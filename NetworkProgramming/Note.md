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

요약
TcpListener에서 서버를 오픈해 놓으면(해당 IP와 포트를 오픈) TcpClient에서 해당 서버에 접근한다.(TcpClient 생성자)
NetworkStream을 통해 서버와 클라이언트 간에 데이터를 주고 받을 수 있다.

