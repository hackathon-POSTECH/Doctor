using RabbitMQ.Client;

namespace DOCTOR.INFRA.RabbitMq;

public interface ICreateChannelRabbitMql
{
    IModel GetChannel();
}
