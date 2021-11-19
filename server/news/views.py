from rest_framework.permissions import AllowAny
from rest_framework.response import Response
from rest_framework.views import APIView
from rest_framework.generics import CreateAPIView

from review.models import Review
from profileUser.models import UserProfil, UserFollowing, UserModel

from .models import News
from .serialaizers import NewsListSerializers, NewsCreateSerializers,ReviewCreateSerializers, UserFollowingerSerializers, UsersProfilSerializers, CreateUserSerializers

# Create your views here.

class NewsListView(APIView):
    """Вывод списка новостей"""

    def get(self, request):
        news = News.objects.all()
        serializerNews = NewsListSerializers(news, many=True)

        return Response(serializerNews.data)

class NewsListCreate(APIView):
    def post(self, request):
        serilazerNews = NewsCreateSerializers(data=request.data)
        if serilazerNews.is_valid():
            serilazerNews.save()
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
    queryset = UserModel.objects.all()
    serializer_class = CreateUserSerializers
    permission_classes = [AllowAny]

    def post(self, request, *args, **kwargs):
        serializer = CreateUserSerializers(data=request.data)
        data = {}
        if serializer.is_valid():
            serializer.save()
            data['response'] = True
            return Response(status=201)

        else:
            return Response(serializer.errors)