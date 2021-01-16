using ApplicationCore.Dtos.Class;
using ApplicationCore.Dtos.HomeWork;
using ApplicationCore.Dtos.Meeting;
using ApplicationCore.Dtos.Object;
using ApplicationCore.Dtos.Student;
using ApplicationCore.Dtos.Teacher;
using ApplicationCore.Entities;
using AutoMapper;

namespace ApplicationCore.profiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            //Source -> Target
            CreateMap<TeachersModel, TeacherReadDto>();
            CreateMap<ClassCreateDto, classesModel>();
            CreateMap<classesModel, ClassReadDto>();
            CreateMap<MeetingCreateDto, MeetingsModel>();
            CreateMap<MeetingsModel, MeetingReadDto>();
            CreateMap<ObjectCreateDto, ObjectsModel>();
            CreateMap<ObjectsModel, ObjectReadDto>();
            CreateMap<HomeWorkCreateDto, HomeWorksModel>();
            CreateMap<HomeWorksModel, HomeWorkReadDto>();
            CreateMap<TeachersModel, HomeWorkTeacherReadDtop>();
            CreateMap<ObjectsModel, HomeWorkObjectReadDto>();
            CreateMap<TeachersModel, MeetingTeacherReadDto>();
            CreateMap<classesModel, MeetingClassReadDto>();
            CreateMap<MeetingsModel, TeacherMeetingReadDto>();
            CreateMap<ObjectsModel, TeacherObjectReadDto>();
            CreateMap<HomeWorksModel, TeacherHomeWorkReadDto>();
            CreateMap<HomeWorksModel, ClassHomeWorksReadDto>();
            CreateMap<ObjectsModel, ClassObjectReadDto>();
            CreateMap<MeetingsModel, ClassMeetingReadDto>();
            CreateMap<classesModel, ClassReadDto>();
            CreateMap<ObjectsModel, ObjectHomeWorksReadDto>();
            CreateMap<StudentsModel, StudentReadDto>();
            CreateMap<classesModel, StudentClassReadDto>();
            CreateMap<StudentsModel, ClassStudentReadDto>();
        }
    }
}