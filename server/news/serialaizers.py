from rest_framework import serializers

from review.models import Review
from .models import News
from profileUser.models import UserProfil, UserFollowing, UserModel


class ReviewCreateSerializers(serializers.ModelSerializer):
    """Список комментариев"""
    class Meta:
        model = Review
        fields = '__all__'



class NewsListSerializers(serializers.ModelSerializer):
    '''Список новостей '''
    review = ReviewCreateSerializers(many=True)
    class Meta:
        model = News
        fields = "__all__"


class NewsCreateSerializers(serializers.ModelSerializer):
    '''Список новостей '''
    class Meta:
        model = News
        fields = "__all__"


class CreateUserSerializers(serializers.ModelSerializer):
    password2 = serializers.CharField()
    email = serializers.EmailField()
    username = serializers.CharField()

    class Meta:
        model = UserModel
        fields = ['email', 'username', 'password', 'password2']

    def save(self, **kwargs):
        user = UserModel(
            email=self.validated_data['email'],
            username=self.validated_data['username']
        )
        password = self.validated_data['password']
        password2 = self.validated_data['password2']
        if password != password2:
            raise serializers.ValidationError({password: "Пароли не совпадают"})
        user.set_password(password)
        user.save()
        return user

class UsersProfilSerializers(serializers.ModelSerializer):
    class Meta:
        model = UserProfil
        fields = "_all__"

class UserFollowingerSerializers(serializers.ModelSerializer):
    class Meta:
        model = UserFollowing
        fields = "_all__"