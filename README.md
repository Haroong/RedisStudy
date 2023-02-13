# 프로젝트 소개
Redis data types에 따라 API를 호출하고 이를 redis-cli에서 확인할 수 있는 프로젝트

# 개발 환경
- C#
- .NET6.0
- Visual Studio 2022
- Redis

# 주요 기능
- `string` 자료형을 이용한 redis 캐싱
- `sorted set` 자료형을 이용한 redis 캐싱

# 사용법
1. `redis-server.exe` 파일 실행(로컬 호스트를 사용함)
2. `redis-cli.exe` 파일 실행
3. 프로젝트 빌드 및 실행
4. API 호출
5. 해당 API의 데이터베이스 번호 SELECT
6. Redis DB에서 요청값 확인
