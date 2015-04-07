FROM microsoft/aspnet:1.0.0-beta3

MAINTAINER Willem Meints <willemm@infosupport.com>

COPY . /usr/src/app

RUN cd /usr/src/app && kpm restore

WORKDIR /usr/src/app
CMD ["k","kestrel"]
