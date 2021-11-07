FROM python

WORKDIR /server

COPY . .

RUN apt install python3.9 && /usr/local/bin/python3 -m pip install --upgrade pip && \
pip install virtualenv && pip install -r Requirements.txt 


CMD [ "python3", "manage.py", "runserver" ]

EXPOSE 8000