from django.contrib.auth.models import User
from rest_framework import permissions
from rest_framework.response import Response
from rest_framework.views import APIView
from rest_framework.generics import CreateAPIView

from review.models import Review
from profileUser.models import UserProfil, UserFollowing

from .models import News
from .serialaizers import NewsListSerializers, NewsCreateSerializers,ReviewCreateSerializers,\
    UserFollowingerSerializers, UsersProfilSerializers, CreateUserSerializers, UsersSeri

# Create your views here.

class NewsListView(APIView):
    """Вывод списка новостей"""
    permission_classes = [permissions.AllowAny]
    def get(self, request):
        news = News.objects.all()
        serializerNews = NewsListSerializers(news, many=True)

        return Response(serializerNews.data)

class NewsListCreate(APIView):
    permission_classes = [permissions.IsAuthenticated]
    def post(self, request):
        serilazerNews = NewsCreateSerializers(data=request.data,
                                              #autor=request.data.get('user_id')
                                              )
        if serilazerNews.is_valid():
            serilazerNews.save()
        else:
            raise ValueError(serilazerNews.errors)
        return Response(status=201)



class ReviewCreateView(APIView):
    '''Добавление комментариев'''
    def post(self, request):
        review = ReviewCreateSerializers(data=request.data)
        if review.is_valid():
            review.save()
            return Response(status=201)
        else:
            return Response(review.errors)

class CreateUser(CreateAPIView):
    queryset = User.objects.all()
    serializer_class = CreateUserSerializers
    permission_classes = [permissions.AllowAny]

    def post(self, request, *args, **kwargs):
        serializer = CreateUserSerializers(data=request.data)
        data = {}
        if serializer.is_valid():
            serializer.save()
            data['response'] = True
            return Response(status=201)

        else:
            return Response(serializer.errors)


class UsersProfilList(APIView):
    """Отображение профиля пользователя"""
    permission_classes = [permissions.AllowAny]

    def get(self, pk):
        user = UserProfil.objects.all()
        serialaizer = UsersProfilSerializers(user, many=True)

        return Response(serialaizer.data)


class Users(APIView):
    permission_classes = [permissions.AllowAny]

    def get(self, pk):
        print(pk)
        user = User.objects.get(user_pk=pk)
        ser =UsersSeri(user, many=True)
        return Response(ser.data)
